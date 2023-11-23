using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator anim;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
        { 
            if(Input.GetAxisRaw("Horizontal") > 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime;

        
        rb.MovePosition(rb.position + movement);

        anim.SetBool("IsMoving", Mathf.Abs(horizontalInput) > 0f || Mathf.Abs(verticalInput) > 0);
    }
}
