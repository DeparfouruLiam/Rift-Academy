using UnityEngine;
using System.Collections;
using System.Linq;

public class SynergyManager : MonoBehaviour
{
    [SerializeField] private SynergyData[] synergies;

    private void Start()
    {
        StartCoroutine(ApplySynergiesDelayed());
    }

    private IEnumerator ApplySynergiesDelayed()
    {
        yield return new WaitForSeconds(2f);
        ApplySynergies();
    }

    public void ApplySynergies()
    {
        CharacterObject[] heroes = FindObjectsByType<CharacterObject>(FindObjectsSortMode.None)
            .Where(h => h.data != null)
            .ToArray();

        Debug.Log("SynergyManager: " + heroes.Length + " héros trouvés");
        Debug.Log("SynergyManager: " + synergies.Length + " synergies configurées");

        foreach (CharacterObject hero in heroes)
        {
            System.Collections.Generic.List<SynergyTier> heroTiers = new System.Collections.Generic.List<SynergyTier>();

            foreach (SynergyData synergy in synergies)
            {
                if (hero.data.synergies == null || !hero.data.synergies.Contains(synergy.dimensionOrClassName)) continue;

                int count = heroes.Count(h => h.data.synergies != null && h.data.synergies.Contains(synergy.dimensionOrClassName));
                int tierIndex = Mathf.Min(count - 1, 4);
                heroTiers.Add(synergy.tiers[tierIndex]);
                Debug.Log(hero.data.characterName + " | synergie [" + synergy.dimensionOrClassName + "] tier " + tierIndex);
            }

            if (heroTiers.Count > 0)
                hero.ApplyAllTiers(heroTiers.ToArray());
        }
    }
}
