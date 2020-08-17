using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    public float moveSpeed;
    public bool facingLeft = true;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var xDir = Input.GetAxisRaw(Consts.Horizontal);
        var yDir = Input.GetAxisRaw(Consts.Vertical);

        SetHorizontalFacing(xDir);

        moveDirection = new Vector2(xDir, yDir).normalized;
        animator.SetFloat(Consts.horizontalMovement, Mathf.Abs(xDir));
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    private void SetHorizontalFacing(float xDir)
    {
        if (Mathf.Abs(xDir) < float.Epsilon)
        {
            return;
        }

        if ((xDir > 0 && facingLeft) || (xDir < 0 && !facingLeft))
        {
            Flip();
        }
    }

    void Flip()
    {
        facingLeft = !facingLeft;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
