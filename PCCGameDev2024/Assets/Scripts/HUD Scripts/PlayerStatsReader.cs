using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsReader : MonoBehaviour
{
    private int HP;
    private int attack;
    private float attackSpeed; 

    public TMP_Text HPField;
    public TMP_Text attackField;
    public TMP_Text attackSpeedField;

    public void RenderStats(){
        HPField.text = "Maximum Integrity: " + PlayerStats.GetMaxHP();
        attackField.text = "Attack Power: " + PlayerStats.GetAttack();
        attackSpeedField.text = "Attack Speed: " + PlayerStats.GetAttackSpeedMult();
    }
}
