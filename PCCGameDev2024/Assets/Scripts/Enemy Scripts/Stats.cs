using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyStats : MonoBehaviour
{   
    private float maxHP;
    private float HP;
    private string tier;

    public void GenerateStats(int tierVal = 1){
        if(tierVal == 1){
            tier = "Low-level T MK I";
            maxHP = 10f;
        }
        else if(tierVal == 2){
            tier = "Low-level T MK II";
            maxHP = 30f;
        }
        else if(tierVal == 3){
            tier = "Low-level D MK III";
            maxHP = 70f;
        }
        else if(tierVal == 4){
            tier = "Mid-level DSM Module";
            maxHP = 150f;
        }
        else if(tierVal == 5){
            tier = "Mid-level NDSM Module MK I";
            maxHP = 200f;
        }
        else if(tierVal == 6){
            tier = "Mid-level NDSM Module MK II";
            maxHP = 300f;
        }
        HP = maxHP;
    }

    public float GetHP(){
        return HP;
    }

    public void SetHP(float val){
        HP = val;
    }

    public float GetMaxHP(){
        return maxHP;
    }

    public string GetTier(){
        return tier;
    }

    //Add code that will scale the HP based on the amount of levels already cleared
}
