using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SalvageController : MonoBehaviour
{
    private bool playerIn = false;

    [SerializeField]
    private TMP_Text HUDToolTip;

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            playerIn = true;
            HUDToolTip.text = "Press <color=red>F</color> to salvage modules";
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            playerIn = false;
            HUDToolTip.text = "";
        }
    }

    void Update(){
        if(Keyboard.current.fKey.wasPressedThisFrame && playerIn){
            //should bring up the module deck;
            print("Salvaging modules");
        }
    }
}
