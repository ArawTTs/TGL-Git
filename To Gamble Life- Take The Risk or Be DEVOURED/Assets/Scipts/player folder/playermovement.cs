using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the movement

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        // Move the rigidbody
        rb.MovePosition(rb.position + movement);
    }
}
