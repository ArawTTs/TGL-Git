using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BattleHUD : MonoBehaviour
{

    public string unitName;
    public TMP_Text nameText;
    public TMP_Text HP;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        HP.text = "Life:  " + unit.currentHP;
    }

    public void SetHP (int hp)
    {
        HP.text = "Life:  " + hp.ToString();
    }
}
