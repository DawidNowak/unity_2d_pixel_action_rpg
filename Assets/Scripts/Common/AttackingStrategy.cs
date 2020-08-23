using System.Linq;
using UnityEngine;

public abstract class AttackingStrategy : MonoBehaviour
{
    public float weaponRange = 20f;
    public float attackRate = 2f;
    public int attackDamage = 1;

    protected Animator animator;
    protected Vector3 attackPoint;

    private float nextAttack = 0f;
    private LayerMask playerLayer;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        playerLayer = LayerMask.GetMask("Player");
    }

    public virtual void ProcessAttack()
    {
        if (Time.time > nextAttack)
        {
            Attack();
        }
    }

    public abstract void PerformAttack(Collider2D player);

    private void Attack()
    {
        HitEnemies();
        nextAttack = Time.time + 1f / attackRate;
    }

    private void HitEnemies()
    {
        var player = PlayerInRange();
        if (player != null)
        {
            animator.SetTrigger(Consts.Attack);
            PerformAttack(player);
        }
    }

    protected virtual Collider2D PlayerInRange()
    {
        return Physics2D.OverlapCircleAll(transform.position + attackPoint, weaponRange, playerLayer).SingleOrDefault();
    }
}
