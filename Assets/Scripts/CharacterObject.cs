using System;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    public CharacterData data;

    [Header("Stats en temps réel")]
    public float currentPv;
    public float currentDefense;
    public float currentDegats;
    public float currentPenetration;
    public float currentVitesseAttaque;
    public float currentManaStat;
    public float currentChanceCritique;
    public float currentDegatsCritique; 

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (data == null) return;

        currentPv = data.pvMax;
        currentDefense = data.defense;
        currentDegats = data.degats;
        currentPenetration = data.penetration;
        currentVitesseAttaque = data.vitesseAttaque;
        currentManaStat = data.manaStat;
        currentChanceCritique = data.chanceCritique;
        currentDegatsCritique = data.degatsCritique;

        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().sprite = data.artwork;
    }

    internal void UpdateStats(SynergyBonus synergyBonus)
    {
        if (data == null) return;

        currentPv = (data.pvMax * synergyBonus.multiPv) + synergyBonus.bonusPv;
        currentDefense = (data.defense * synergyBonus.multiDefense) + synergyBonus.bonusDefense;
        currentDegats = (data.degats * synergyBonus.multiDegats) + synergyBonus.bonusDegats;
        currentPenetration = (data.penetration * synergyBonus.multiPenetration) + synergyBonus.bonusPenetration;
        currentVitesseAttaque = (data.vitesseAttaque * synergyBonus.multiVitesseAttaque) + synergyBonus.bonusVitesseAttaque;
        currentManaStat = (data.manaStat * synergyBonus.multiMana) + synergyBonus.bonusMana;
        currentChanceCritique = Mathf.Clamp(data.chanceCritique + synergyBonus.bonusChanceCritique, 0f, 1f);
        currentDegatsCritique = (data.degatsCritique * synergyBonus.multiDegatsCritique) + synergyBonus.bonusDegatsCritique;

        if (synergyBonus.upgradeUltime)
        {
            
        }
    }
}