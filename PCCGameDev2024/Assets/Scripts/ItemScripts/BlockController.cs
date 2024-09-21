using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int moduleSlots;
    public List<Module> moduleList;
    public List<Block> blockList;

    public string conditionFunc;

    public string conditionField;
    public string conditionOperator;
    public string conditionValue;

    [SerializeField]
    private TMP_Text InfoText;

    private string ReadModules(){
        string moduleText = "";
        foreach(Module m in moduleList){
            moduleText += m.ModuleAttribute + " +" + m.ModuleValue + "\n";
        }
        return moduleText;
    }

    private string ReadBlocks(){
        string blockText = "";
        foreach(Block b in blockList){
            blockText += "if(" + conditionFunc + "){\n"
                             + ReadModules() + ""
                             + ReadBlocks() + ""
                             + RenderBlanks() +
                            "}";
        }
        return blockText;
    }

    private string RenderBlanks(){
        int blanksAmount = moduleSlots - (moduleList.Count + blockList.Count);
        string blankText = "";
        for(int i = 0; i < blanksAmount; i++){
            blankText += "[-Blank Slot-]\n";
        }
        return blankText;
    }

    public void DisplayData(){
        if(conditionFunc != null && conditionFunc != ""){
            InfoText.text = "if(" + conditionFunc + "){\n"
                             + ReadModules() + ""
                             + ReadBlocks() + ""
                             + RenderBlanks() +
                            "}";
        }
        else{
            string condition = ">";
            if(conditionOperator == "gt"){
                condition = ">";
            }
            else if(conditionOperator == "lt"){
                condition = "<";
            }
            InfoText.text = "if(" + conditionField + condition + conditionValue + "){\n"
                             + ReadModules() + ""
                             + ReadBlocks() + ""
                             + RenderBlanks() +
                            "}";
        }
    }

    void Start(){
        DisplayData();
    }

    public void OverrideValuesFrom(Block source){
        moduleSlots = source.moduleSlots;
        moduleList = source.moduleList;
        blockList = source.blockList;
        conditionFunc = source.conditionFunc;
        conditionField = source.conditionField;
        conditionOperator = source.conditionOperator;
        conditionValue = source.conditionValue;

    }
}
