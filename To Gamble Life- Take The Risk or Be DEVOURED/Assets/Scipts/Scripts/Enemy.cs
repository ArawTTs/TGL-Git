using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationDelay = 0.5f; 
    public float lifespan = 4f; 

    private Vector2 lastKnownPlayerPosition;
    private bool playerFound = false;
    private Vector2 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifespan); 
    }

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerFound = true;
            lastKnownPlayerPosition = playerObject.transform.position;
        }

        if (playerFound)
        {
            moveDirection = (lastKnownPlayerPosition - (Vector2)transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            RotateTowardsPlayerWithDelay();
        }
    }

    void RotateTowardsPlayerWithDelay()
    {
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationDelay * Time.deltaTime);
    }
}