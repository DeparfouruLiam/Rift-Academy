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

    public void ApplyAllTiers(SynergyTier[] tiers)
    {
        if (data == null) return;

        float multiPv = 1f, bonusPv = 0f;
        float multiDefense = 1f, bonusDefense = 0f;
        float multiDegats = 1f, bonusDegats = 0f;
        float multiPenetration = 1f, bonusPenetration = 0f;
        float multiVitesse = 1f, bonusVitesse = 0f;
        float multiMana = 1f, bonusMana = 0f;
        float bonusChanceCrit = 0f;
        float multiDegatsCrit = 1f, bonusDegatsCrit = 0f;
        bool upgradeUltime = false;

        foreach (SynergyTier tier in tiers)
        {
            multiPv *= tier.multiPv;         bonusPv += tier.bonusPv;
            multiDefense *= tier.multiDefense; bonusDefense += tier.bonusDefense;
            multiDegats *= tier.multiDegats;   bonusDegats += tier.bonusDegats;
            multiPenetration *= tier.multiPenetration; bonusPenetration += tier.bonusPenetration;
            multiVitesse *= tier.multiVitesseAttaque; bonusVitesse += tier.bonusVitesseAttaque;
            multiMana *= tier.multiMana;       bonusMana += tier.bonusMana;
            bonusChanceCrit += tier.bonusChanceCritique;
            multiDegatsCrit *= tier.multiDegatsCritique; bonusDegatsCrit += tier.bonusDegatsCritique;
            if (tier.upgradeUltime) upgradeUltime = true;
        }

        currentPv = (data.pvMax * multiPv) + bonusPv;
        currentDefense = (data.defense * multiDefense) + bonusDefense;
        currentDegats = (data.degats * multiDegats) + bonusDegats;
        currentPenetration = (data.penetration * multiPenetration) + bonusPenetration;
        currentVitesseAttaque = (data.vitesseAttaque * multiVitesse) + bonusVitesse;
        currentManaStat = (data.manaStat * multiMana) + bonusMana;
        currentChanceCritique = data.chanceCritique + bonusChanceCrit;
        currentDegatsCritique = (data.degatsCritique * multiDegatsCrit) + bonusDegatsCrit;

        Debug.Log("[" + data.characterName + "] ApplyAllTiers → dégâts=" + currentDegats + " vitesse=" + currentVitesseAttaque);
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