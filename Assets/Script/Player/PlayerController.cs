using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Setting")]
    [SerializeField] float moveSpeed = 5f;

    InputReader input;
    Rigidbody rb;

    void Awake()
    {
        input = GetComponent<InputReader>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.MoveInput.x, 0f, input.MoveInput.y);
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
}