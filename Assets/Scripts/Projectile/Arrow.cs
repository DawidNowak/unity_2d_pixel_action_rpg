using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public float speed = 100f;


    void Awake()
    {
        Debug.Log("Arrow Awake");
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = transform.up * speed;
    }
}
