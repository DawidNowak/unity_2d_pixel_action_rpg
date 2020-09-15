using System.Linq;
using TMPro;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    public StatisticsSystem statictics;
    public GameObject damagePopup;
    public int health;
    public int mana;

    protected float hpPercWhenFlee = 0f;

    protected virtual void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        health = statictics.HitPoints.CurrentValue;
        mana = statictics.ManaPoints.CurrentValue;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        DisplayDamagePopup(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual GameObject DisplayDamagePopup(int damage)
    {
        var popup = Instantiate(damagePopup, transform.position, Quaternion.identity);
        popup.GetComponent<TextMesh>().text = damage.ToString();
        var renderer = popup.GetComponent<MeshRenderer>();
        renderer.sortingOrder = 1000;
        return popup;
    }

    protected bool NeedToFlee()
    {
        return (float)health / statictics.HitPoints.CurrentValue <= hpPercWhenFlee;
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
