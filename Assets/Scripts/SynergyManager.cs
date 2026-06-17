using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Simplified Synergy Manager - applies bonuses based on character dimensions and classes.
/// KISS principle: clear, focused, minimal logic.
/// </summary>
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
        RefreshSceneSynergies();
    }

    /// <summary>Find a synergy by name and type.</summary>
    public SynergyData FindSynergy(string name, SynergyData.SynergyType type)
    {
        return string.IsNullOrEmpty(name) ? null : synergies.FirstOrDefault(s => s != null && s.synergyType == type && s.dimensionOrClassName == name);
    }

    /// <summary>Get the bonus for a synergy based on unit count.</summary>
    public SynergyBonus GetBonusFor(SynergyData data, int count)
    {
        if (data?.tiers == null || data.tiers.Length == 0) return new SynergyBonus();
        int tierIndex = Mathf.Min(count - 1, data.tiers.Length - 1);
        return data.tiers[Mathf.Max(0, tierIndex)].bonus ?? new SynergyBonus();
    }

    /// <summary>Combine two bonuses (multipliers multiply, flats add).</summary>
    private SynergyBonus CombineBonuses(SynergyBonus a, SynergyBonus b)
    {
        return new SynergyBonus
        {
            // Multiplicative bonuses
            multiPv = a.multiPv * b.multiPv,
            multiDefense = a.multiDefense * b.multiDefense,
            multiDegats = a.multiDegats * b.multiDegats,
            multiPenetration = a.multiPenetration * b.multiPenetration,
            multiVitesseAttaque = a.multiVitesseAttaque * b.multiVitesseAttaque,
            multiMana = a.multiMana * b.multiMana,
            multiDegatsCritique = a.multiDegatsCritique * b.multiDegatsCritique,

            // Additive bonuses
            bonusPv = a.bonusPv + b.bonusPv,
            bonusDefense = a.bonusDefense + b.bonusDefense,
            bonusDegats = a.bonusDegats + b.bonusDegats,
            bonusPenetration = a.bonusPenetration + b.bonusPenetration,
            bonusVitesseAttaque = a.bonusVitesseAttaque + b.bonusVitesseAttaque,
            bonusMana = a.bonusMana + b.bonusMana,
            bonusChanceCritique = a.bonusChanceCritique + b.bonusChanceCritique,
            bonusDegatsCritique = a.bonusDegatsCritique + b.bonusDegatsCritique,

            upgradeUltime = a.upgradeUltime || b.upgradeUltime,
        };
    }

    /// <summary>Count units by synergy type (dimension or classe).</summary>
    private void CountSynergies(CharacterObject[] chars, Dictionary<string, int> dimCounts, Dictionary<string, int> classCounts)
    {
        foreach (var c in chars)
        {
            if (c?.data == null) continue;

            if (!string.IsNullOrEmpty(c.data.dimension))
                dimCounts[c.data.dimension] = dimCounts.GetValueOrDefault(c.data.dimension, 0) + 1;

            if (!string.IsNullOrEmpty(c.data.classe))
                classCounts[c.data.classe] = classCounts.GetValueOrDefault(c.data.classe, 0) + 1;
        }
    }

    /// <summary>Apply synergies to all characters in the scene.</summary>
    [ContextMenu("Refresh Scene Synergies")]
    public void RefreshSceneSynergies()
    {
        var chars = Object.FindObjectsByType<CharacterObject>(FindObjectsSortMode.None);
        if (chars.Length == 0) return;

        var dimCounts = new Dictionary<string, int>();
        var classCounts = new Dictionary<string, int>();

        CountSynergies(chars, dimCounts, classCounts);

        foreach (var c in chars)
        {
            if (c?.data == null) continue;

            SynergyBonus totalBonus = new SynergyBonus();

            // Apply dimension synergy
            if (!string.IsNullOrEmpty(c.data.dimension) && dimCounts.TryGetValue(c.data.dimension, out int dimCount))
            {
                var dimSynergy = FindSynergy(c.data.dimension, SynergyData.SynergyType.Dimension);
                totalBonus = CombineBonuses(totalBonus, GetBonusFor(dimSynergy, dimCount));
            }

            // Apply class synergy
            if (!string.IsNullOrEmpty(c.data.classe) && classCounts.TryGetValue(c.data.classe, out int classCount))
            {
                var classSynergy = FindSynergy(c.data.classe, SynergyData.SynergyType.Classe);
                totalBonus = CombineBonuses(totalBonus, GetBonusFor(classSynergy, classCount));
            }

            c.UpdateStats(totalBonus);
        }

#if UNITY_EDITOR
        Debug.Log($"[Synergy] Applied to {chars.Length} characters | Dimensions: {dimCounts.Count} | Classes: {classCounts.Count}");
#endif
    }

#if UNITY_EDITOR
    [ContextMenu("Scan All Synergies (Editor Only)")]
    public void ScanAllSynergies()
    {
        synergies.Clear();
        var guids = UnityEditor.AssetDatabase.FindAssets("t:SynergyData");

        foreach (var guid in guids)
        {
            var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<SynergyData>(path);
            if (asset != null) synergies.Add(asset);
        }

        UnityEditor.EditorUtility.SetDirty(this);
        Debug.Log($"[Synergy] Scanned and found {synergies.Count} synergy assets");
    }
#endif
}
