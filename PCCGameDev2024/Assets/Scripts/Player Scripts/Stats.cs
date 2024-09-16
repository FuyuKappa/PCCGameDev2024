using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Stats : MonoBehaviour
{
    private float baseMoveSpeed = 10f;
    private float attackSpeedMult = 1f;
    private float attackInterval = 0.3f;
    private int attack = 9;
    private int maxHP = 100;
    private int HP = 80;

    public int GetAttack(){
        return attack;
    }

    public float GetAttackSpeedMult(){
        return attackSpeedMult;
    }

    public float GetAttackInterval(){
        return attackInterval;
    }
    
    public int GetMaxHP(){
        return maxHP;
    }

    public int GetHP(){
        return HP;
    }

    public float GetBaseMoveSpeed(){
        return baseMoveSpeed;
    }
}
