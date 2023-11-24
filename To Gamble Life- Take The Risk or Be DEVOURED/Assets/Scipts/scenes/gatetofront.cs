using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gatetofront : MonoBehaviour
{
    public int sceneBuildIdIndex;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneBuildIdIndex, LoadSceneMode.Single);
        }
    }
}
