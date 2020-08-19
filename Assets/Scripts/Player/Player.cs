using UnityEngine;
using static Assets.Scripts.Utils.Enums;
using static Assets.Scripts.Utils.Extensions;

public class Player : MonoBehaviour
{
    #region Private
    private Animator animator;
    private Rigidbody2D rigidBody;

    private bool isArmed;
    private float attackRate = 2f;
    private float nextAttack = 0f;

    private Vector2 facingDirection;
    private Vector2 moveDirection;
    #endregion

    #region Public
    public float moveSpeed;

    public Transform attackPosition;
    public float weaponRange = 8f;
    public LayerMask destructibleLayers;
    public int attackDamage = 2;
    #endregion

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ProcessArming();
        ProcessAttack();
    }

    void FixedUpdate()
    {
        ProcessInputs();
        Animate();
        Move();
    }

    private void ProcessArming()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isArmed = !isArmed;
            animator.SetBool(Consts.IsArmed, isArmed);
        }
    }

    private void ProcessAttack()
    {
        if (isArmed && Input.GetKeyDown(KeyCode.X) && Time.time > nextAttack)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger(Consts.Attack);
        nextAttack = Time.time + 1f / attackRate;

        HitEnemies();
    }

    private void HitEnemies()
    {
        var direction = DetermineDirection();
        attackPosition.position = transform.position + direction.ConvertToVector3() * 15f;

        var enemies = GetEnemiesInRange(direction);

        foreach (var enemy in enemies)
        {
            enemy.GetComponent<LivingObject>().TakeDamage(attackDamage);
        }
    }

    private Collider2D[] GetEnemiesInRange(Facing direction)
    {
        Collider2D[] hitEnemies;
        if (direction == Facing.Left || direction == Facing.Right)
            hitEnemies = Physics2D.OverlapCircleAll(attackPosition.position, weaponRange, destructibleLayers);
        else
            hitEnemies = Physics2D.OverlapCapsuleAll(attackPosition.position, new Vector2(4 * weaponRange, 2 * weaponRange), CapsuleDirection2D.Horizontal, 0f, destructibleLayers);

        return hitEnemies;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPosition == null)
            return;

        Gizmos.DrawWireSphere(attackPosition.position, weaponRange);
    }

    private Facing DetermineDirection()
    {
        if (facingDirection == null || facingDirection == Vector2.zero)
        {
            return Facing.Down;
        }

        var x = facingDirection.x;
        var y = facingDirection.y;
        var xLength = Mathf.Abs(x);
        var yLength = Mathf.Abs(y);

        if (xLength > yLength)
            return x > 0 ? Facing.Right : Facing.Left;
        else if (xLength < yLength)
            return y > 0 ? Facing.Top : Facing.Down;
        else //Equal
        {
            if (x > 0 && y > 0)
                return Facing.Right;
            else if (x < 0 && y > 0)
                return Facing.Left;
            else
                return Facing.Down;
        }
    }

    private void ProcessInputs()
    {
        var xDir = Input.GetAxisRaw(Consts.Horizontal);
        var yDir = Input.GetAxisRaw(Consts.Vertical);

        moveDirection = new Vector2(xDir, yDir).normalized;

        if (moveDirection != Vector2.zero)
        {
            facingDirection = moveDirection;
        }
    }

    private void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void Animate()
    {
        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat(Consts.Horizontal, moveDirection.x);
            animator.SetFloat(Consts.Vertical, moveDirection.y);
        }

        animator.SetFloat(Consts.MoveSpeed, Mathf.Clamp(moveDirection.magnitude, 0f, 1f));
    }
}
