using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private readonly float moveSpeed = 1f;
    private readonly float displayTime = 1f;

    private Vector3 target;

    void Start()
    {
        target = transform.position + new Vector3(1f, 1f);
        Destroy(gameObject, displayTime);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
