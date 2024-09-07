using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{   
    private float attackSpeedMult = 1f;
    private float attackInterval = 0.5f;
    public bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CaptureAttackInput(InputAction.CallbackContext context){
        if(context.performed && GetComponent<PlayerMovement>().isDashing == false){
           isAttacking = true; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isAttacking){
            print("Attack detected");
            isAttacking = false;
        }
    }
}
