using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public int maxRange = 10;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;
    public TMP_Text diceOutcome;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);

        playerUnit = playerGO.GetComponent<Unit>();
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "Enemy Found " + enemyUnit.unitName + " !";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();

        if(state == BattleState.ENEMYTURN)
        {
            // enemy turn her?
            // delete if not used
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "What's your choice?";
    }

    #region Persuade Button
    IEnumerator PlayerPersuade()
    {
        int dice = Random.Range(1, maxRange);
        diceOutcome.text = "" + dice;
        Debug.Log("Enemy's current HP: " + enemyUnit.currentHP);

        if (enemyUnit.currentHP > 0) 
        {
            if (dice >= enemyUnit.currentHP)
            {
                dialogueText.text = "Hit!";
                bool isDead = enemyUnit.TakeDamage();
                enemyHUD.SetHP(enemyUnit.currentHP);
                Debug.Log("Enemy's current HP: " + enemyUnit.currentHP);

                if (isDead)
                {
                    // if dead in here
                }
            }
            else
            {
                dialogueText.text = "Bullet hell mode";
                playerUnit.PlayerTakeDamage(); // Check this
                playerHUD.SetHP(playerUnit.currentHP);
                SceneManager.LoadScene("Battle Hell Mode");
            }
        }
        yield return new WaitForSeconds(2f);

        // Check enemy if dead
        // State
    }

    public void OnPersuadeBtn()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerPersuade());
    }
    #endregion

    #region Distract Button
    IEnumerator PlayerDistract()
    {
        int dice = Random.Range(1, maxRange);
        diceOutcome.text = "" + dice;

        if (dice >= enemyUnit.currentHP)
        {
            dialogueText.text = "Healed!";
            playerUnit.HealPlayer();
            playerHUD.SetHP(playerUnit.currentHP);
            Debug.Log("Enemy's current HP: " + enemyUnit.currentHP);
        }
        else
        {
            dialogueText.text = "Bullet hell mode";
            SceneManager.LoadScene("Battle Hell Mode");
        }

        yield return new WaitForSeconds(2f);
    }


    public void OnDistractBtn()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerDistract());
    }

    #endregion

    #region Item Button
    IEnumerator PlayerItem()
    {
        int dice = Random.Range(1, maxRange);
        diceOutcome.text = "" + dice;

        if (dice >= playerUnit.currentHP)
        {
            dialogueText.text = "Go to Item";
            // Item code here
        }
        else
        {
            dialogueText.text = "Bullet hell mode";
            SceneManager.LoadScene("Battle Hell Mode");
        }

        yield return new WaitForSeconds(2f);
    }


    public void OnItemBtn()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerItem());
    }
    #endregion

    #region Run Button
    IEnumerator PlayerRun()
    {

        int dice = Random.Range(1, maxRange);
        diceOutcome.text = "" + dice;

        if (dice >= playerUnit.currentHP)
        {
            dialogueText.text = "Run";
            SceneManager.LoadScene("menu");
        }
        else
        {
            dialogueText.text = "Bullet hell mode";
            SceneManager.LoadScene("Battle Hell Mode");
        }


        yield return new WaitForSeconds(2f);
    }

    public void OnRunBtn()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        StartCoroutine(PlayerRun());
    }
    #endregion
}

