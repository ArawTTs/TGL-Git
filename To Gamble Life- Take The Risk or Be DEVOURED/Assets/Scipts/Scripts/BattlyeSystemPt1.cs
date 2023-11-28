using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BattlyeSystemPt1 : MonoBehaviour
{
    public BattleState state;
    public GameObject playerPrefab;
    public Transform playerBattleStation;

    public TMP_Text diceNum;

    private Unit playerUnit;
 
    private GameObject instantiatedPlayer;

    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(Battle());
    }

    IEnumerator Battle()
    {
        instantiatedPlayer = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = instantiatedPlayer.GetComponent<Unit>();

        if (playerUnit != null)
        {
            diceNum.text = "d " + playerUnit.currentHP;
        }

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
    }

    public void UpdateCurrentHPText(int currentHP)
    {
        diceNum.text = "d " + currentHP; 

        if (currentHP >= 18)
        {
            diceNum.text = "Game Over";
            //delete
            //update here
        }
    }
}
