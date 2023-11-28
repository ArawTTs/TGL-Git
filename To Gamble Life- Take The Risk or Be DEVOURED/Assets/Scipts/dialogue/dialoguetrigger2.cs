using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoguetrigger2 : MonoBehaviour
{
    public GameObject gameobject;
    public Dialogue dialogue;

    void Update(){
        StartCoroutine(delayStart());
    }
    private IEnumerator delayStart()
    {
        yield return new WaitForSeconds(2f);
        gameobject.SetActive(true);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
