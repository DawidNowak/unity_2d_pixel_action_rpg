using Assets.Scripts.Utils;
using UnityEngine;
using static Assets.Scripts.Utils.Enums;

public class Wandering : WalkingBase
{
    private Animator animator;

    private Vector3 target;
    private Vector3 direction;
    private float idleTime = 2f;
    private float nextMove = 0f;

    public float restDuration = 2f;
    public float moveProbability = 0.25f;
    public float moveSpeed = 80f;
    public float moveDistance = 20f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case WalkingState.Standing:
            default:
                if (ShouldMove())
                    MoveToRandomPosition();
                break;

            case WalkingState.Walking:
                ProcessWalking();
                break;
        }
    }

    private bool ShouldMove()
    {
        if (Time.time > nextMove)
        {
            nextMove = Time.time + idleTime;
            return Random.Range(0f, 1f) < moveProbability;
        }

        return false;
    }

    private void MoveToRandomPosition()
    {
        direction = DetermineDirection();
        target = transform.position + direction * moveDistance;
        state = WalkingState.Walking;
        animator.SetFloat(Consts.Horizontal, direction.x);
        animator.SetFloat(Consts.Vertical, direction.y);
        animator.SetFloat(Consts.MoveSpeed, moveSpeed);
    }

    private Vector3 DetermineDirection()
    {
        var facing = (Facing)Random.Range(1, 5);
        return facing.ConvertToVector3();
    }

    private void ProcessWalking()
    {
        if (target == null || transform.position == target)
        {
            animator.SetFloat(Consts.Horizontal, direction.x * Vector2.kEpsilon);
            animator.SetFloat(Consts.Vertical, direction.y * Vector2.kEpsilon);
            animator.SetFloat(Consts.MoveSpeed, 0f);
            state = WalkingState.Standing;
            return;
        }
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, moveSpeed * Time.deltaTime);
    }
}
