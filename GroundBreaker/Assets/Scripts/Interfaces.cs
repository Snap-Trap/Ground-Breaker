using UnityEngine;

public class Interfaces
{
    public interface IDamageable
    {
        public void TakeDamage(int damage);
        public void Die();
    }
}
