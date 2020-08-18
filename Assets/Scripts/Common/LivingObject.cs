using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    public int MaxHealth = 1;
    public int Health;

    protected virtual void Start()
    {
        Health = MaxHealth;
    }

    protected virtual void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        enabled = false;
    }
}
