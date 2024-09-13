using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Purchasing.MiniJSON;

public class WorldInteraction : MonoBehaviour
{
    private Transform InfoPanel;
    private TextMeshPro InfoText;

    void Start(){
        InfoPanel = this.transform.GetChild(0).transform;
        InfoText = InfoPanel.GetChild(0).GetComponent<TextMeshPro>();

        Module module =  this.AddComponent<Module>();
        JsonUtility.FromJsonOverwrite(this.GetComponent<Module>().GetStats(), module); 

        InfoText.text = module.ModuleTier + " " + module.ModuleAttribute +  " module\n" + module.ModuleAttribute + " +" + module.ModuleValue;
    }
}
