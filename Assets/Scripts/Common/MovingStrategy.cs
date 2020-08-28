using System;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

public abstract class MovingStrategy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float acceptableDistanceFromTarget = 0.02f;
    public Action TargetReachedCallback;

    protected Animator animator;
    protected Rigidbody2D rb;
    protected WalkingState state;
    protected Vector3 target;

    public virtual void Start()
    {
        state = WalkingState.Standing;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tag = collision.gameObject.tag;
        if (tag == Consts.Wall || tag == Consts.Player)
        {
            transform.position = transform.position + (transform.position - target).normalized * 0.1f;
            StopMovement();
        }
    }

    private void ProcessMove()
    {
        var direction = (target - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            animator.SetFloat(Consts.Horizontal, direction.x);
            animator.SetFloat(Consts.Vertical, direction.y);
        }
    }

    protected virtual void CheckMovementFinished()
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
            var current = new Vector2(transform.position.x, transform.position.y);
            rb.velocity = (new Vector2(target.x, target.y) - current).normalized * moveSpeed;

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
