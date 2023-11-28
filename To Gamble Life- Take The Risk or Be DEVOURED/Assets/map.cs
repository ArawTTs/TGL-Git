using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject mapOBJ;

    public void activateMapOn()
    {
        mapOBJ.SetActive(true);
    }
    public void activateMapOff()
    {
        mapOBJ.SetActive(false);
    }
}
