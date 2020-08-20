
using UnityEngine;

public class Rabilion : EnemyController
{
    private float hpPercWhenFlee = 0.4f;
    private Animator animator;
    private bool wasHit = false;

    protected override void Start()
    {
        maxHealth = 5;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 20f);
        

        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        animator.SetTrigger(Consts.Hurt);
        base.TakeDamage(damage);

        if (health > 0)
        {
            if (!wasHit)
            {
                wasHit = true;
                Destroy(movingStrategy);
                movingStrategy = ChasingStrategy.CreateComponent(gameObject, searchDelay: 0.5f);
            }

            if (NeedToFlee())
            {
                StartFleeing();
            }
        }
    }

    private bool NeedToFlee()
    {
        return (float)health / maxHealth <= hpPercWhenFlee;
    }

    private void StartFleeing()
    {
        Destroy(movingStrategy);
        movingStrategy = FleeingStrategy.CreateComponent(gameObject);
    }

    protected override void Die()
    {
        Destroy(movingStrategy);
        animator.SetBool(Consts.IsDead, true);
        base.Die();
    }
}
