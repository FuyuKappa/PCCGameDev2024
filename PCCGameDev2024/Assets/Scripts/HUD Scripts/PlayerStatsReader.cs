using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsReader : MonoBehaviour
{
    private int HP;
    private int attack;
    private float attackSpeed; 

    [SerializeField]
    private Stats stats;

    public TMP_Text HPField;
    public TMP_Text attackField;
    public TMP_Text attackSpeedField;

    public void RenderStats(){
        HPField.text = "Maximum Integrity: " + stats.GetMaxHP();
        attackField.text = "Attack Power: " + stats.GetAttack();
        attackSpeedField.text = "Attack Speed: " + stats.GetAttackSpeedMult();
    }
}
