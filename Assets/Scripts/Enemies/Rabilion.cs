
using UnityEngine;

public class Rabilion : LivingObject
{
    private Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    protected override void TakeDamage(int damage)
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
