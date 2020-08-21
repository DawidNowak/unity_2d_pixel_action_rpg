using System.Linq;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    public int maxHealth = 1;
    public int health;

    public float hpPercWhenFlee = 0f;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        health = maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected bool NeedToFlee()
    {
        return (float)health / maxHealth <= hpPercWhenFlee;
    }

    protected virtual void Die()
    {
        DisableCollider();
        DisableAllScripts();
    }

    private void DisableCollider()
    {
        var collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }
    }

    private void DisableAllScripts()
    {
        MonoBehaviour[] scripts = gameObject
            .GetComponents<MonoBehaviour>()
            .Where(script => script.name != nameof(LivingObject))
            .ToArray();
        foreach (MonoBehaviour script in scripts)
        {
            script.enabled = false;
        }

        enabled = false;
    }
}
