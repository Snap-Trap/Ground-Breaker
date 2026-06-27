//using UnityEngine;

//public class PlayerHealth : MonoBehaviour, IDamageable
//{
//    public delegate void HealthChanged(int current, int maxHealth);
//    public HealthChanged healthChanged;

//    private HealthEventChannel healthEventChannel;

//    private int maxHealth = 10;
//    private int currentHealth;

//    public void Start()
//    {
//        currentHealth = maxHealth;

//        OnHealthChanged?.Invoke(currentHealth, maxHealth);

//        healthEventChannel.RaiseEvent(currentHealth, maxHealth);
//    }

//    public void TakeDamage(int damage)
//    {
//        currentHealth -= damage;
//        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

//        OnHealthChanged?.Invoke(currentHealth, maxHealth);

//        healthEventChannel.RaiseEvent(currentHealth, maxHealth);

//        if (currentHealth <= 0)
//        {
//            Die();
//        }
//    }

//    public void Die()
//    {

//    }
//}
