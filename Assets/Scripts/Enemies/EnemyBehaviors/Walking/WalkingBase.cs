using System;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

public class WalkingBase : MonoBehaviour
{
    public float moveSpeed = 80f;

    protected Animator animator;

    protected WalkingState state;

    protected Vector3 target;

    protected virtual void Start()
    {
        state = WalkingState.Standing;
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
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
        var current = new Vector2(transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(current, target, moveSpeed * Time.deltaTime);

        var direction = (target - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            animator.SetFloat(Consts.Horizontal, direction.x);
            animator.SetFloat(Consts.Vertical, direction.y);
        }
    }

    protected void CheckMovementFinished()
    {
        if (target == null || transform.position == target)
        {
            animator.SetFloat(Consts.MoveSpeed, 0f);
            state = WalkingState.Standing;
        }
    }

    protected void Move(Vector2 target)
    {
        this.target = target;
        animator.SetFloat(Consts.MoveSpeed, moveSpeed);
        state = WalkingState.Walking;
    }

}
