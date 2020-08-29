using System;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public abstract class MovingStrategy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float acceptableDistanceFromTarget = 0.02f;
    public Action TargetReachedCallback;

    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D coll;
    protected WalkingState state;
    protected Vector3 target;

    public virtual void Start()
    {
        state = WalkingState.Standing;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    public virtual void FixedUpdate()
    {
        switch (state)
        {
            case WalkingState.Standing:
            default:
                break;
            case WalkingState.Walking:
                ProcessMove();
                CheckMovementFinished();
                break;
        }
    }

    private void ProcessMove()
    {
        var direction = (target - transform.position).normalized;

        var position = coll.bounds.center;
        var obstacle = Physics2D.Raycast(position, direction, 0.2f);

        if (obstacle.collider == null)
        {
            if (direction != Vector3.zero)
            {
                animator.SetFloat(Consts.Horizontal, direction.x);
                animator.SetFloat(Consts.Vertical, direction.y);
            }

            var current = new Vector2(transform.position.x, transform.position.y);
            rb.velocity = (new Vector2(target.x, target.y) - current).normalized * moveSpeed;
        }
        else
        {
            StopMovement();
        }
    }

    private void CheckMovementFinished()
    {
        if (target == null || IsTargetInRange())
        {
            StopMovement();
        }
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
        animator.SetFloat(Consts.MoveSpeed, 0f);
        state = WalkingState.Standing;
    }

    protected void Move(Vector2 target)
    {
        this.target = target;

        if (!IsTargetInRange())
        {
            animator.SetFloat(Consts.MoveSpeed, moveSpeed);
            state = WalkingState.Walking;
        }
        else
        {
            StopMovement();
            TargetReachedCallback?.Invoke();
        }
    }
    protected bool IsTargetInRange()
    {
        return Vector3.Distance(transform.position, target) <= acceptableDistanceFromTarget;
    }
}
