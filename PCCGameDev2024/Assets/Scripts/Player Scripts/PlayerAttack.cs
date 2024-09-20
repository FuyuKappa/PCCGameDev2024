using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{   
    private float attackSpeedMult;
    private float attackStart;
    public bool isAttacking = false;
    private WeaponAnimation weapon;

    [SerializeField]
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        weapon = player.GetComponentInChildren<WeaponAnimation>();     
    }

    public void CaptureAttackInput(InputAction.CallbackContext context){
        if(context.performed && GetComponent<PlayerMovement>().isDashing == false && isAttacking == false){
           isAttacking = true;
           attackStart = Time.time; 
           weapon.Attack();
        }
    }

    public void HandleHit(Collider other){
        if(other.gameObject.CompareTag("Enemy") && isAttacking){
            int attack = PlayerStats.GetAttack();
            other.gameObject.GetComponent<EnemyController>().HandleHit(attack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isAttacking){
            float attackInterval = PlayerStats.GetAttackInterval();
            if(Time.time - attackStart >= attackInterval) isAttacking = false;
        }
    }
}
