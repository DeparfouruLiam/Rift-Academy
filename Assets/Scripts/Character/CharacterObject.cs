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
    
    // Store synergy bonus to ensure it persists
    private SynergyBonus currentSynergyBonus = new SynergyBonus();
    private bool isInitialized = false;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (data == null || isInitialized) return;

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
            
        isInitialized = true;
    }

    internal void UpdateStats(SynergyBonus synergyBonus)
    {
        if (data == null) return;
        
        // Store synergy bonus for persistence
        currentSynergyBonus = synergyBonus;
        ApplyStatsWithSynergy();
    }
    
    /// <summary>Apply stats with current synergy bonus. Called after Initialize() to ensure proper application.</summary>
    private void ApplyStatsWithSynergy()
    {
        if (data == null) return;

        currentPv = (data.pvMax * currentSynergyBonus.multiPv) + currentSynergyBonus.bonusPv;
        currentDefense = (data.defense * currentSynergyBonus.multiDefense) + currentSynergyBonus.bonusDefense;
        currentDegats = (data.degats * currentSynergyBonus.multiDegats) + currentSynergyBonus.bonusDegats;
        currentPenetration = (data.penetration * currentSynergyBonus.multiPenetration) + currentSynergyBonus.bonusPenetration;
        currentVitesseAttaque = (data.vitesseAttaque * currentSynergyBonus.multiVitesseAttaque) + currentSynergyBonus.bonusVitesseAttaque;
        currentManaStat = (data.manaStat * currentSynergyBonus.multiMana) + currentSynergyBonus.bonusMana;
        currentChanceCritique = Mathf.Clamp(data.chanceCritique + currentSynergyBonus.bonusChanceCritique, 0f, 1f);
        currentDegatsCritique = (data.degatsCritique * currentSynergyBonus.multiDegatsCritique) + currentSynergyBonus.bonusDegatsCritique;

        if (currentSynergyBonus.upgradeUltime)
        {
            
        }
    }

    public int GetDamageWithCritical()
    {
        float baseDamage = currentDegats;
        float chanceCrit = Mathf.Clamp01(currentChanceCritique);
        float surplus = Mathf.Max(0f, currentChanceCritique - 1f);
        float critMultiplier = currentDegatsCritique + (surplus * 0.6f);
        
        bool isCritical = UnityEngine.Random.value < chanceCrit;
        int damage = (int)(baseDamage * (isCritical ? critMultiplier : 1f));
        
        if (isCritical)
        {
            Debug.Log("CRITIQUE! Dégâts: " + damage + " (base: " + baseDamage + " x " + critMultiplier + ")");
        }
        
        return damage;
    }
}