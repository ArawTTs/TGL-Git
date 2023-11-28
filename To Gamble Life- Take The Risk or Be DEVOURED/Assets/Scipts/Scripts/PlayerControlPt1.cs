using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlPt1 : MonoBehaviour
{

    private Text diceNumber;
    private Unit playerUnit;


    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public int life = 1;

    private BattlyeSystemPt1 battleSystem;

    void Start()
    {
        playerUnit = GetComponent<Unit>();
        battleSystem = FindObjectOfType<BattlyeSystemPt1>();
    }


    void Update()
    {
        /*   simple player mouse follow
         *   Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           transform.position = new Vector2(mousePos.x, mousePos.y); */

        

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; 

        float distance = Vector3.Distance(transform.position, mousePos);
        float moveStep = moveSpeed * Time.deltaTime;

        if (distance > moveStep)
        {
            transform.position = Vector3.Lerp(transform.position, mousePos, moveStep / distance);
        }

        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collision with Enemy detected.");
            playerUnit.PlayerTakeDamage(); // ++health

         
            if (battleSystem != null)
            {
                battleSystem.UpdateCurrentHPText(playerUnit.currentHP);
            }
        }
    }

    

}
