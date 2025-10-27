using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 movementDir = Vector2.zero;

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
        transform.position += (Vector3)move * moveSpeed * Time.fixedDeltaTime;
    }
}