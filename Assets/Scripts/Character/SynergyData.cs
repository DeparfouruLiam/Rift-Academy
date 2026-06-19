using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Synergy", menuName = "Gacha/Synergy")]
public class SynergyData : ScriptableObject
{
    [Header("Nom de la synergie")]
    public string dimensionOrClassName;

    [Header("Paliers (5 niveaux)")]
    public SynergyTier[] tiers;

    private void OnEnable()
    {
        if (tiers == null || tiers.Length != 5)
        {
            tiers = new SynergyTier[5];
            for (int i = 0; i < 5; i++)
            {
                tiers[i] = new SynergyTier();
            }
        }
    }
}

[System.Serializable]
public class SynergyTier
{
    [Header("Multiplicateurs")]
    public float multiPv = 1f;
    public float multiDefense = 1f;
    public float multiDegats = 1f;
    public float multiPenetration = 1f;
    public float multiVitesseAttaque = 1f;
    public float multiMana = 1f;
    public float multiDegatsCritique = 1f;

    [Header("Bonus directs")]
    public float bonusPv = 0f;
    public float bonusDefense = 0f;
    public float bonusDegats = 0f;
    public float bonusPenetration = 0f;
    public float bonusVitesseAttaque = 0f;
    public float bonusMana = 0f;
    public float bonusChanceCritique = 0f;
    public float bonusDegatsCritique = 0f;

    [Header("Upgrade")]
    public bool upgradeUltime = false;

    [Header("Abilités")]
    public List<string> abilities = new List<string>();
}
