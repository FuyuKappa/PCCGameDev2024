using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class NextNodeController : MonoBehaviour
{
    private bool playerIn = false;

    [SerializeField]
    private TMP_Text HUDToolTip;

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            playerIn = true;
            HUDToolTip.text = "Press <color=red>enter</color> to go the next area";
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            playerIn = false;
            HUDToolTip.text = "";
        }
    }

    void Update(){
        if(Keyboard.current.enterKey.wasPressedThisFrame && playerIn){
            SceneManager.LoadScene("DesktopTestLevel");
        }
    }
}
