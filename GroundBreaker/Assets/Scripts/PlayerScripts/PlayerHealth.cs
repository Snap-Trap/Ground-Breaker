using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public MenuManager menuManager;
    
    public int maxHealth = 5;
    public int currentHealth;

    public float Iframes = 1f;
    
    public bool Invincible;
    
    public string damageObjectTag;
    
    public Image healthFill;

    public void Awake()
    {
        menuManager = FindFirstObjectByType<MenuManager>();
        currentHealth = maxHealth;
    }

    public void Update()
    {
        float displayHealth = (float)currentHealth / maxHealth;
        healthFill.fillAmount = Mathf.Clamp01(displayHealth);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(damageObjectTag))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        if (Invincible) return;
        
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(InvincibilityFrames());
    }
    
    private IEnumerator InvincibilityFrames()
    {
        Invincible = true;
        yield return new WaitForSeconds(Iframes);
        Invincible = false;
    }

    public void Die()
    {
        menuManager.OpenFailMenu();
    }
}
