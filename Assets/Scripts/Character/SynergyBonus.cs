using UnityEngine;

[System.Serializable]
public class SynergyBonus
{
    public float multiPv = 1f;
    public float multiDefense = 1f;
    public float multiDegats = 1f;
    public float multiPenetration = 1f;
    public float multiVitesseAttaque = 1f;
    public float multiMana = 1f;
    public float multiDegatsCritique = 1f;

    public float bonusPv = 0f;
    public float bonusDefense = 0f;
    public float bonusDegats = 0f;
    public float bonusPenetration = 0f;
    public float bonusVitesseAttaque = 0f;
    public float bonusMana = 0f;
    public float bonusChanceCritique = 0f;
    public float bonusDegatsCritique = 0f;

    public bool upgradeUltime = false;

    public SynergyBonus() {}
}

