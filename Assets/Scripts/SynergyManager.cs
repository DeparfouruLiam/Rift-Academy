using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SynergyManager : MonoBehaviour
{
    public static SynergyManager Instance { get; private set; }

    [Header("Assign synergies here (or use ScanAllSynergies in editor)")]
    public List<SynergyData> synergies = new List<SynergyData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(ApplySynergiesDelayed());
    }

    private System.Collections.IEnumerator ApplySynergiesDelayed()
    {
        yield return null;
        RefreshSceneSynergies();
    }

    public SynergyData FindSynergy(string name, SynergyData.SynergyType type)
    {
        if (string.IsNullOrEmpty(name)) return null;
        return synergies.FirstOrDefault(s => s != null && s.synergyType == type && s.dimensionOrClassName == name);
    }

    public SynergyBonus GetBonusFor(SynergyData data, int count)
    {
        if (data == null) return new SynergyBonus();
        int index = Mathf.Clamp(count - 1, 0, 4);
        if (data.tiers == null || data.tiers.Length == 0) return new SynergyBonus();
        if (index >= data.tiers.Length) index = data.tiers.Length - 1;
        return data.tiers[index].bonus ?? new SynergyBonus();
    }

    public void ApplySynergyToCharacter(CharacterObject character, string synergyName, SynergyData.SynergyType type, int count)
    {
        if (character == null || character.data == null) return;
        var sd = FindSynergy(synergyName, type);
        var bonus = GetBonusFor(sd, count);
        character.UpdateStats(bonus);
    }

    // Combine two SynergyBonus into a new one (multipliers multiply, flats add)
    private SynergyBonus CombineBonuses(SynergyBonus a, SynergyBonus b)
    {
        var result = new SynergyBonus();
        result.multiPv = a.multiPv * b.multiPv;
        result.multiDefense = a.multiDefense * b.multiDefense;
        result.multiDegats = a.multiDegats * b.multiDegats;
        result.multiPenetration = a.multiPenetration * b.multiPenetration;
        result.multiVitesseAttaque = a.multiVitesseAttaque * b.multiVitesseAttaque;
        result.multiMana = a.multiMana * b.multiMana;
        result.multiDegatsCritique = a.multiDegatsCritique * b.multiDegatsCritique;

        result.bonusPv = a.bonusPv + b.bonusPv;
        result.bonusDefense = a.bonusDefense + b.bonusDefense;
        result.bonusDegats = a.bonusDegats + b.bonusDegats;
        result.bonusPenetration = a.bonusPenetration + b.bonusPenetration;
        result.bonusVitesseAttaque = a.bonusVitesseAttaque + b.bonusVitesseAttaque;
        result.bonusMana = a.bonusMana + b.bonusMana;
        result.bonusChanceCritique = a.bonusChanceCritique + b.bonusChanceCritique;
        result.bonusDegatsCritique = a.bonusDegatsCritique + b.bonusDegatsCritique;

        result.upgradeUltime = a.upgradeUltime || b.upgradeUltime;
        return result;
    }

    // Scan the active scene for CharacterObject, compute counts per synergy, and apply combined bonuses.
    [ContextMenu("Refresh Scene Synergies")]
    public void RefreshSceneSynergies()
    {
        var chars = Object.FindObjectsByType<CharacterObject>(FindObjectsSortMode.None);
        var dimCounts = new Dictionary<string, int>();
        var classCounts = new Dictionary<string, int>();

        foreach (var c in chars)
        {
            if (c == null || c.data == null) continue;
            var d = c.data.dimension;
            var cl = c.data.classe;
            if (!string.IsNullOrEmpty(d))
            {
                if (!dimCounts.ContainsKey(d)) dimCounts[d] = 0;
                dimCounts[d]++;
            }
            if (!string.IsNullOrEmpty(cl))
            {
                if (!classCounts.ContainsKey(cl)) classCounts[cl] = 0;
                classCounts[cl]++;
            }
        }

        foreach (var c in chars)
        {
            if (c == null || c.data == null) continue;

            SynergyBonus total = new SynergyBonus();

            if (!string.IsNullOrEmpty(c.data.dimension) && dimCounts.TryGetValue(c.data.dimension, out int dc))
            {
                var sd = FindSynergy(c.data.dimension, SynergyData.SynergyType.Dimension);
                var bonus = GetBonusFor(sd, dc);
                total = CombineBonuses(total, bonus);
            }

            if (!string.IsNullOrEmpty(c.data.classe) && classCounts.TryGetValue(c.data.classe, out int cc))
            {
                var sd = FindSynergy(c.data.classe, SynergyData.SynergyType.Classe);
                var bonus = GetBonusFor(sd, cc);
                total = CombineBonuses(total, bonus);
            }

            c.UpdateStats(total);
        }

#if UNITY_EDITOR
        Debug.Log($"Applied synergies for {chars.Length} characters (dims: {dimCounts.Count}, classes: {classCounts.Count}).");
#endif
    }

#if UNITY_EDITOR
    [ContextMenu("Scan All Synergies (Editor Only)")]
    public void ScanAllSynergies()
    {
        synergies.Clear();
        var guids = UnityEditor.AssetDatabase.FindAssets("t:SynergyData");
        foreach (var g in guids)
        {
            var path = UnityEditor.AssetDatabase.GUIDToAssetPath(g);
            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<SynergyData>(path);
            if (asset != null) synergies.Add(asset);
        }
        UnityEditor.EditorUtility.SetDirty(this);
        Debug.Log($"Found {synergies.Count} synergy assets.");
    }
#endif
}
