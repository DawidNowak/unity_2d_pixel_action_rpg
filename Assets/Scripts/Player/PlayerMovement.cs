using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    public float moveSpeed;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ProcessInputs();
        Animate();
        Move();
    }

    private void ProcessInputs()
    {
        var xDir = Input.GetAxisRaw(Consts.Horizontal);
        var yDir = Input.GetAxisRaw(Consts.Vertical);

        moveDirection = new Vector2(xDir, yDir).normalized;
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
