using System.Linq;
using TMPro;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour
{
    public GameObject damagePopup;
    public int health;
    public int mana;

    protected int maxHealth = 1;
    protected int maxMana = 1;
    protected float hpPercWhenFlee = 0f;

    protected virtual void Start()
    {
        Init();
        damagePopup = (GameObject)Resources.Load("Prefabs/Common/UI/DamagePopup", typeof(GameObject));
    }

    protected virtual void Init()
    {
        health = maxHealth;
        mana = maxMana;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        displayDamagePopup(damage);

        if (health <= 0)
        {
            Die();
        }
    }

    private void displayDamagePopup(int damage)
    {
        var popup = Instantiate(damagePopup, transform.position, Quaternion.identity);
        popup.GetComponent<TextMeshPro>().text = damage.ToString();
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
