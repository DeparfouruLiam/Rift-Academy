using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Synergy", menuName = "Gacha/Synergy")]
public class SynergyData : ScriptableObject
{
    public enum SynergyType { Dimension, Classe }

    [Header("Dimension ou Classe")]
    public string dimensionOrClassName;

    [Header("Type")]
    public SynergyType synergyType;

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
    public SynergyBonus bonus = new SynergyBonus();
    public List<string> abilities = new List<string>();
}
