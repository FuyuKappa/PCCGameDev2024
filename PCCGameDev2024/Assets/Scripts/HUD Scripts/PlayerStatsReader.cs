using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerStatsReader : MonoBehaviour
{
    private int HP;
    private int attack;
    private float attackSpeed; 

    public TMP_Text HPField;
    public TMP_Text attackField;
    public TMP_Text attackSpeedField;
    public RectTransform inventory;

    public GameObject blockPrefab;

    public void RenderStats(){
        HPField.text = "Maximum Integrity: " + PlayerStats.GetMaxHP();
        attackField.text = "Attack Power: " + PlayerStats.GetAttack();
        attackSpeedField.text = "Attack Speed: " + PlayerStats.GetAttackSpeedMult();

        if(Inventory.blockList != null){
            foreach(Block b in Inventory.blockList){
                GameObject display = Instantiate(blockPrefab);
                display.GetComponent<Block>().OverrideValuesFrom(b);
                display.transform.SetParent(inventory);
            }
        }
    }

    public void Unrender(){
        int sentinel = 0;
        while(inventory.childCount > 0 && sentinel < 10){
            Destroy(inventory.GetChild(0).gameObject);
            sentinel++; 
        }
    }
}
