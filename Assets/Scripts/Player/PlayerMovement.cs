using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector2 moveDirection;

    public float moveSpeed;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        var xDir = Input.GetAxisRaw(Consts.Horizontal);
        var yDir = Input.GetAxisRaw(Consts.Vertical);

        moveDirection = new Vector2(xDir, yDir).normalized;
    }

    void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
