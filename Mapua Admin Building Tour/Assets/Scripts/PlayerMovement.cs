using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Rigidbody2D body;
    private Vector2 movementDirection;

    void Start() {
        // Upon start, get access to the rigidbody that this object is attached to
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        // Check for keyboard input
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    void FixedUpdate() {
        body.velocity = movementDirection * movementSpeed;
        // body.velocity.Normalize();
    }
}
