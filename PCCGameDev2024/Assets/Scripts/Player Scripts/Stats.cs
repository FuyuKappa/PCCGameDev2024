using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public static class PlayerStats
{
    private static float baseMoveSpeed = 10f;
    private static float baseAttackSpeedMult = 1f;
    private static float attackSpeedMult = 1f;

    private static float attackInterval = 0.3f;

    private static int baseAttack = 9;
    private static int attack = 9;

    private static int baseMaxHP = 100;
    private static int maxHP = 100;
    private static int HP = 80;

    public static void SetBases(int _baseMaxHP, int _baseAttack, float _baseAttackSpeedMult){
        baseMaxHP = _baseMaxHP;
        baseAttack = _baseAttack;
        baseAttackSpeedMult = _baseAttackSpeedMult;
        maxHP = _baseMaxHP;
        attack = _baseAttack;
        attackSpeedMult = _baseAttackSpeedMult;
        HP = maxHP - 20;
        
    }

    public static int GetAttack(){
        return attack;
    }

    public static float GetAttackSpeedMult(){
        return attackSpeedMult;
    }

    public static float GetAttackInterval(){
        return attackInterval;
    }
    
    public static int GetMaxHP(){
        return maxHP;
    }

    public static int GetHP(){
        return HP;
    }

    public static float GetBaseMoveSpeed(){
        return baseMoveSpeed;
    }
}
