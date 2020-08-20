
using UnityEngine;

public class Rabilion : EnemyController
{
    private Animator animator;

    protected override void Start()
    {
        movingStrategy = WanderingStrategy.CreateComponent(gameObject, 20f);

        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void TakeDamage(int damage)
    {
        animator.SetTrigger(Consts.Hurt);
        base.TakeDamage(damage);
    }

    protected override void Die()
    {
        animator.SetBool(Consts.IsDead, true);
        base.Die();
    }
}
