using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;

public class WorldInteraction : MonoBehaviour
{
    [SerializeField]
    private Canvas InfoPanelCanvas;
    [SerializeField]
    private TMP_Text InfoText;
    [SerializeField]
    private BoxCollider playerDetectionBounds;

    void Start(){        
        Module module =  this.AddComponent<Module>();
        JsonUtility.FromJsonOverwrite(this.GetComponent<Module>().GetStats(), module); 

        InfoText.text = module.ModuleTier + " " + module.ModuleAttribute +  " module\n" + module.ModuleAttribute + " +" + module.ModuleValue;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            InfoPanelCanvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            InfoPanelCanvas.gameObject.SetActive(false);
        }
    }
}
