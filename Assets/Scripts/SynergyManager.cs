using UnityEngine;
using System.Collections.Generic;

public class SynergyManager : MonoBehaviour
{
    public static SynergyManager Instance;

    private List<CharacterObject> activeCharacters = new List<CharacterObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterCharacter(CharacterObject character)
    {
        if (!activeCharacters.Contains(character))
        {
            activeCharacters.Add(character);
            RecalculateSynergies();
        }
    }

    public void UnregisterCharacter(CharacterObject character)
    {
        if (activeCharacters.Contains(character))
        {
            activeCharacters.Remove(character);
            RecalculateSynergies();
        }
    }

    [ContextMenu("Recalculate Now")]
    public void RecalculateSynergies()
    {
        Dictionary<Dimension, int> dimCounts = new Dictionary<Dimension, int>();
        
        dimCounts[Dimension.Cyberpunk] = 0;
        dimCounts[Dimension.Sylvestre] = 0;
        dimCounts[Dimension.Atlantis] = 0;
        dimCounts[Dimension.DarkFantasy] = 0;
        dimCounts[Dimension.AcademieMagie] = 0;

        foreach (var c in activeCharacters)
        {
            if (c.data != null)
            {
                dimCounts[c.data.dimension]++;
            }
        }

        SynergyBonus cyberBonus = new SynergyBonus();
        if (dimCounts[Dimension.Cyberpunk] >= 3)
        {
            cyberBonus.multiDegats = 1.5f; // +50%
            cyberBonus.upgradeUltime = true;
        }

        foreach (var c in activeCharacters)
        {
            if (c.data.dimension == Dimension.Cyberpunk)
            {
                c.UpdateStats(cyberBonus);
            }
            else
            {
                c.UpdateStats(new SynergyBonus());
            }
        }
        
        Debug.Log("Synergies mises à jour !");
    }
}