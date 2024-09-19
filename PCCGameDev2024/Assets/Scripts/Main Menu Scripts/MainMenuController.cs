using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject optionsMenu;

    public void RenderStartMenu(){
        if(optionsMenu.activeSelf) optionsMenu.SetActive(false);

        startMenu.SetActive(true);
    }

    public void RenderOptionsMenu(){
        if(startMenu.activeSelf) startMenu.SetActive(false);

        optionsMenu.SetActive(true);
    }
}
