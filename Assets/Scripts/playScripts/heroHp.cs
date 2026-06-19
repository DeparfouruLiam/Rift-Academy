using UnityEngine;
using System.Collections;

public class heroHp : MonoBehaviour
{
    public float heroHealth=0;
    private CharacterObject character;
    private float originalAttackSpeed;
    public float savedAttackSpeedBeforeDeath;
    private int originalLayer;

    void Start()
    {
        character = GetComponent<CharacterObject>();
        originalLayer = gameObject.layer;
        if (character != null && character.data != null)
        {
            heroHealth = character.data.pvMax;
            originalAttackSpeed = character.currentVitesseAttaque;
            Debug.Log("Santé du héro initialisée: " + heroHealth);
        }
    }

    public void TakeDamage(int damage)
    {
        heroHealth -= damage;
        Debug.Log("Héro prend " + damage + " dégâts. HP: " + heroHealth);

        if (heroHealth <= 0)
        {
            savedAttackSpeedBeforeDeath = character.currentVitesseAttaque;
            StartCoroutine(StunCoroutine());
        }
    }

    IEnumerator StunCoroutine()
    {
        if (character == null) yield break;

        gameObject.layer = 0;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
            sprite.color = new Color(1f, 1f, 1f, 0.5f);
        character.currentVitesseAttaque = 0.1f;
        
        yield return new WaitForSeconds(10f);
        
        gameObject.layer = 14;
        if (sprite != null)
            sprite.color = new Color(1f, 1f, 1f, 1f);
        character.currentVitesseAttaque = savedAttackSpeedBeforeDeath;
        heroHealth = character.data.pvMax;
    }
}

