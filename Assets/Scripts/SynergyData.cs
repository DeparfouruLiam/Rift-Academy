using UnityEngine;

public enum Dimension { Cyberpunk, Sylvestre, Atlantis, DarkFantasy, AcademieMagie }
public enum Classe { Combattant, Mage, Range, Tank, Assassin, Support }

[System.Serializable]
public class SynergyBonus
{
    public float multiDegats = 1f;
    public float bonusDefense = 0f;
    public float multiMana = 1f;
    public bool upgradeUltime = false;

    public SynergyBonus() {
        multiDegats = 1f;
        bonusDefense = 0f;
        multiMana = 1f;
        upgradeUltime = false;
    }
}