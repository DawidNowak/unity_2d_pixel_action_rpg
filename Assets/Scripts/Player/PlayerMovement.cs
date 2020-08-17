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
        var xDir = Input.GetAxisRaw(Consts.Horizontal);
        var yDir = Input.GetAxisRaw(Consts.Vertical);

        moveDirection = new Vector2(xDir, yDir).normalized;
        animator.SetFloat(Consts.Horizontal, xDir);
        animator.SetFloat(Consts.Vertical, yDir);
        animator.SetFloat(Consts.Magnitude, moveDirection.magnitude);
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
