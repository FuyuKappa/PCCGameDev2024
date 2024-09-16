using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{   
    //=========Variables
    private Vector3 moveVector;
    private Vector3 LastKnownGoodVector;
    private CharacterController controller;
    public Camera mainCamera;
    public Transform player;

    private float baseMoveSpeed;

    private float moveSpeed;
    private readonly float dashSpeedMultiplier = 5f;
    private const float dashDuration = 0.5f; //You should only dash for 2 seconds
    private float startDashTime;
    public bool isDashing = false;

    //========Funcs   

    void Start()
    {
        controller = GetComponent<CharacterController>();
        baseMoveSpeed = GetComponent<Stats>().GetBaseMoveSpeed();
        moveSpeed = baseMoveSpeed;
    }

    public void CaptureMoveInput(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
    }

    public void CaptureDashInput(InputAction.CallbackContext context){
        bool isAttacking = GetComponent<PlayerAttack>().isAttacking;
        if(context.performed && !isDashing){
            isDashing = true;
            moveSpeed *= dashSpeedMultiplier;
            startDashTime = Time.time;
            if(isAttacking) GetComponent<PlayerAttack>().isAttacking = false;
        }
    }

    private void rotateToMouse(){
        Vector3 mousePosition = Input.mousePosition;

        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit)){
            player.transform.LookAt(new Vector3(hit.point.x, player.position.y, hit.point.z));
        }
    }

    private void Move(){
        Vector3 direction = new(LastKnownGoodVector.x, 0, LastKnownGoodVector.y);
        rotateToMouse();
        controller.Move(moveSpeed * Time.deltaTime * direction);
    }

    public void Update()
    {
        if(!isDashing){
            LastKnownGoodVector = moveVector;
            Move();
        }
        else if(isDashing){
            if(moveSpeed <= baseMoveSpeed){
                isDashing = false;
                moveSpeed = baseMoveSpeed;
            }
            else{
                Move();

                float t = (Time.time - startDashTime) / dashDuration; 
                moveSpeed = Mathf.SmoothStep(moveSpeed, baseMoveSpeed, t);
            }
        }
    }
}
