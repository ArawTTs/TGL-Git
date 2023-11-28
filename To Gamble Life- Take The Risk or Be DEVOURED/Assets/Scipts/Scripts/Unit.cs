using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;
  
    public bool TakeDamage()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PlayerTakeDamage()
    {
        currentHP++;
        if(currentHP >= 18)
        {
            SceneManager.LoadScene("BulletHell1");
        }
    }

    public void HealPlayer()
    {
        if (currentHP > 1) 
        {
            currentHP--; 
        }
    }
}
