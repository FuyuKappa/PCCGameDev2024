using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Module : MonoBehaviour
{   
    public string ModuleTier;
    public string ModuleAttribute;
    public int ModuleValue;

    [SerializeField]
    private TMP_Text InfoText;

    void Start(){        
        //JsonUtility.FromJsonOverwrite(this.GetComponent<Module>().GetStats(), module); 
        if(InfoText != null) InfoText.text = ModuleTier + " " + ModuleAttribute +  " module\n" + ModuleAttribute + " +" + ModuleValue;
    }

    public string GetStats(){
        return JsonUtility.ToJson(this);
    }    
}
