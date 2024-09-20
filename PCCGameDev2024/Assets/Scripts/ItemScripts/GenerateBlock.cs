using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GenerateBlock
{
    public static void Generate(Block block, RectTransform moduleDeck, int attributeSeed = -1){
        if(attributeSeed == -1) attributeSeed = (int)Random.Range(1, 3); //Higher bound is excluded
        block.moduleSlots = Random.Range(2,4);

        Module module = block.AddComponent<Module>();
        GenerateModule.Generate(module, moduleDeck);
        block.moduleList.Add(module);

        int seed = (int)Random.Range(0f, 100f);

        //there's no randomization yet, let's make this work first
        if(attributeSeed == 1) {
            block.conditionFunc = "enemyKilled()";
        } //enemies killed
        else if(attributeSeed == 2) {
            block.conditionField = "HP";
            block.conditionOperator = "gt"; //greater than
            block.conditionValue = "50";
        } //HP

        block.transform.SetParent(moduleDeck);
    }
}
