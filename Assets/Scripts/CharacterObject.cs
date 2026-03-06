using System;
using UnityEngine;

public class CharacterObject : MonoBehaviour
{
    public CharacterData data;

    [Header("Stats en temps réel")]
    public float currentPv;
    public float currentVitesseAttaque;
    public float currentManaStat; 

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (data == null) return;

        currentPv = data.pvMax;
        currentVitesseAttaque = data.vitesseAttaque;
        currentManaStat = data.manaStat;

        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().sprite = data.artwork;

        SynergyManager.Instance?.RegisterCharacter(this);
    }

    internal void UpdateStats(SynergyBonus synergyBonus)
    {
        throw new NotImplementedException();
    }
}