
using UnityEngine;

public class Rabilion : EnemyController
{
    private float hpPercWhenFlee = 0.4f;
    private Animator animator;

    protected override void Start()
    {
        maxHealth = 5;
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 20f);
        //movingStrategy = ChasingStrategy.CreateComponent(gameObject, 100f);
        //movingStrategy = FleeingStrategy.CreateComponent(gameObject, 100f);

        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        animator.SetTrigger(Consts.Hurt);
        base.TakeDamage(damage);

        if (NeedToFlee())
        {
            StartFleeing();
        }
    }

    private bool NeedToFlee()
    {
        return (float)health / maxHealth <= hpPercWhenFlee;
    }

    private void StartFleeing()
    {
        movingStrategy = FleeingStrategy.CreateComponent(gameObject);
    }

    protected override void Die()
    {
        movingStrategy = null;
        animator.SetBool(Consts.IsDead, true);
        base.Die();
        
    }
}
