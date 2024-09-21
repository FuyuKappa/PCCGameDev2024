using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SalvageController : MonoBehaviour
{
    private bool playerIn = false;
    private GameObject[] moduleList;

    [SerializeField]
    private TMP_Text HUDToolTip;

    [SerializeField]
    private RectTransform salvageScreen;

    [SerializeField]
    private RectTransform moduleDeck;

    [SerializeField]
    private GameObject modulePrefab;
    [SerializeField]
    private GameObject blockPrefab;

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

    public void ShowScreen(){
        salvageScreen.gameObject.SetActive(true);
    }

    public void CloseScreen(){
        salvageScreen.gameObject.SetActive(false);
    }

    private void ResetDeck(int modulesToGenerate){
        while(moduleDeck.childCount > 0){
            moduleDeck.GetChild(0).gameObject.SetActive(false);
            moduleDeck.GetChild(0).SetParent(null);  
        }

        if(moduleList != null){
            for(int i = 0; i < modulesToGenerate; i++){
                moduleList[i].transform.SetParent(moduleDeck);
                moduleList[i].SetActive(true);
            }
        }
        else{
            for(int i = 0; i < modulesToGenerate; i++){
                moduleList ??= new GameObject[modulesToGenerate];

                int seed = Random.Range(0,2);
                GameObject module;

                if(seed == 0){
                    module = Instantiate(modulePrefab);
                    GenerateModule.Generate(module.GetComponent<Module>(), moduleDeck);
                }
                else{
                    module = Instantiate(blockPrefab);   
                    GenerateBlock.Generate(module.GetComponent<Block>(), moduleDeck);
                }  
                moduleList[i] = module;
            }
        }
    }

    void Update(){
        if(Keyboard.current.fKey.wasPressedThisFrame && playerIn){
            if(salvageScreen.gameObject.activeSelf == false){
                ShowScreen();
                ResetDeck(3);
            }
            else{
                CloseScreen();
            }
        }
    }
}
