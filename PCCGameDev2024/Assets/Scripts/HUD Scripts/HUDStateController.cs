using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUDStateController : MonoBehaviour
{
    private int state;

    public GameObject pause;
    public PlayerStatsReader reader;
    /*  
        states:
            0 = normal game-proper hud
            1 = pause menu
    */
    void Start(){
        state = 0;
    }

    void Update(){
        if(Keyboard.current.escapeKey.wasPressedThisFrame && state == 0){ //Show pause screen
            reader.RenderStats();
            pause.SetActive(true);
            Time.timeScale = 0f;
            state = 1;
        }
        else if(Keyboard.current.escapeKey.wasPressedThisFrame && state == 1){ //Hide pause screen
            reader.Unrender();
            pause.SetActive(false);
            Time.timeScale = 1f;
            state  = 0;
        }
    }
}
