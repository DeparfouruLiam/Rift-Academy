using UnityEngine;

[CreateAssetMenu(fileName = "NouveauPerso", menuName = "Gacha/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Synergies")]
    public Dimension dimension;
    public Classe classe;

    [Header("Stats de Combat")]
    public float pvMax = 100f;
    public float defense = 10f;
    public float degats = 20f;
    public float penetration = 0f;
    public float vitesseAttaque = 1f;
    public float manaStat = 1f; // Ton multiplicateur de temps d'attente
    
    [Header("Critiques")]
    [Range(0, 1)] public float chanceCritique = 0.1f;
    public float degatsCritique = 1.5f;

    [Header("Visuel")]
    public Sprite artwork;
}