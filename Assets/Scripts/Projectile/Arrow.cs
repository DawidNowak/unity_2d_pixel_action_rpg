using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rigidBody;

    public int attackDamage = 1;
    public float speed = 4f;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.GetComponent<EnemyController>() != null)
        {
            return;
        }

        var player = hitInfo.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }

        Destroy(gameObject);
    }
}
