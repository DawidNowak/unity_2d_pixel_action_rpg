using UnityEngine;

public abstract class EnemyController : LivingObject
{
    protected bool wasHit = false;

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

    protected virtual void FixedUpdate()
    {
        if (movingStrategy != null)
        {
            movingStrategy.FixedUpdate();
        };
    }

    protected virtual void StartFleeing()
    {
        Destroy(movingStrategy);
        movingStrategy = FleeingStrategy.CreateComponent(gameObject);
    }

    protected override void Die()
    {
        movingStrategy.StopMovement();
        Destroy(movingStrategy);
        animator.SetBool(Consts.IsDead, true);
        base.Die();
    }
}
