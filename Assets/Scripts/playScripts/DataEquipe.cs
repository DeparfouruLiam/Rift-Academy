using UnityEngine;

[CreateAssetMenu(fileName = "NouvelleDataEquipe", menuName = "Créer Sauvegarde Equipe")]
public class DataEquipe : ScriptableObject
{
    public GameObject[] herosChoisis = new GameObject[5];
}