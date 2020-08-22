using UnityEngine;

public abstract class EnemyController : LivingObject
{
    protected Animator animator;

    protected MovingStrategy movingStrategy;
    protected AttackingStrategy attackingStrategy;

    public override void TakeDamage(int damage)
    {
        animator.SetTrigger(Consts.Hurt);

        base.TakeDamage(damage);
    }

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();

        if (movingStrategy != null)
        {
            movingStrategy.Start();
        };
    }

    protected virtual void Update()
    {
        if (movingStrategy != null)
        {
            movingStrategy.Update();
        };
    }

    protected override void Die()
    {
        Destroy(movingStrategy);
        animator.SetBool(Consts.IsDead, true);
        base.Die();
    }
}
