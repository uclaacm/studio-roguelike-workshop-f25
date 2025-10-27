using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 movementDir = Vector2.zero;

    void Start()
    {
        Debug.Log("PlayerMovement script initialized.");
    }

    public void OnMove(InputValue inputValue)
    {
        movementDir = inputValue.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(movementDir.x, movementDir.y);
        rb.linearVelocity = move * moveSpeed;
    }
}