using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour les boutons Recommencer/Quitter

public class DeathZone : MonoBehaviour
{
    [Header("Interface")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("Statistiques")]
    public int BaseHP = 100;

    private void Start()
    {
        // Sécurité : On s'assure que le jeu tourne à vitesse normale et que l'écran est caché au lancement
        Time.timeScale = 1f;
        
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // --- SÉCURITÉ : On vérifie que c'est bien un ENNEMI ! ---
        if (collision.CompareTag("Enemy"))
        {
            BaseHP -= 1;
            Debug.Log("Ouch ! La base est touchée. HP restants : " + BaseHP);
            
            // On détruit le monstre qui a attaqué la base
            Destroy(collision.gameObject);

            // Vérification du Game Over
            if (BaseHP <= 0)
            {
                ActiverGameOver();
            }
        }
    }

    void ActiverGameOver()
    {
        Debug.Log("Game Over ! La base est détruite.");

        // 1. Afficher l'écran de défaite
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }

        // 2. Mettre le jeu en PAUSE (arrête les mouvements et les spawners)
        Time.timeScale = 0f; 
    }

    // --- FONCTIONS POUR TES BOUTONS D'INTERFACE ---

    public void RetourMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Select"); // Remplace par le nom exact de ta scène de menu
    }
}