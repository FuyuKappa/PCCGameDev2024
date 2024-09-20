using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GenerateModule
{
    public static int GenerateAtkModule(int tier, int seed){
        int ModuleValue;
        if(tier == 0){ //common
            ModuleValue = 1 + Random.Range(-1, 2);
        }
        else if(tier == 1){ //uncommon
            ModuleValue = 5 + Random.Range(-1, 5);
        }
        else if(tier == 2){ //rare
            ModuleValue = 10 + Random.Range(-1, 4);
        }
        else if(tier == 3){ //precious
            ModuleValue = 14 + Random.Range(-1, 3);
        }
        else if(tier == 4){ //legendary
            ModuleValue = 17 + Random.Range(-1, 3);
        }
        else if(tier == 5){ //cosmic
            ModuleValue = 25 + Random.Range(-1, 4);
        }
        else{ //godly
            ModuleValue = 40 + Random.Range(-1, 10);
        }
        return ModuleValue++; //this is to compensate that the random's max is exclusive
    }

    public static int GenerateAtkSpdModule(int tier, int seed){
        int ModuleValue;
        if(tier == 0){ //common
            ModuleValue = 8 + Random.Range(-1, 8);
        }
        else if(tier == 1){ //uncommon
            ModuleValue = 20 + Random.Range(-1, 3);
        }
        else if(tier == 2){ //rare
            ModuleValue = 35 + Random.Range(-1, 3);
        }
        else if(tier == 3){ //precious
            ModuleValue = 40 + Random.Range(-1, 3);
        }
        else if(tier == 4){ //legendary
            ModuleValue = 70 + Random.Range(-1, 20);
        }
        else if(tier == 5){ //cosmic
            ModuleValue = 100 + Random.Range(-1, 20);
        }
        else{ //godly
            ModuleValue = 150 + Random.Range(-1, 50);
        }
        return ModuleValue++; //this is to compensate that the random's max is exclusive
    }

    public static int GenerateHPModule(int tier, int seed){
        int ModuleValue;
        if(tier == 0){ //common
            ModuleValue = 10 + Random.Range(-1, 5);
        }
        else if(tier == 1){ //uncommon
            ModuleValue = 50 + Random.Range(-1, 25);
        }
        else if(tier == 2){ //rare
            ModuleValue = 100 + Random.Range(-1, 50);
        }
        else if(tier == 3){ //precious
            ModuleValue = 300 + Random.Range(-1, 150);
        }
        else if(tier == 4){ //legendary
            ModuleValue = 750 + Random.Range(-1, 300);
        }
        else if(tier == 5){ //cosmic
            ModuleValue = 1000 + Random.Range(-1, 500);
        }
        else{ //godly
            ModuleValue = 2000 + Random.Range(-1, 1000);
        }
        return ModuleValue++; //this is to compensate that the random's max is exclusive
    }
    
    public static void Generate(Module module, RectTransform moduleDeck = null, int tier = 0, int attributeSeed = -1){
        if(attributeSeed == -1) attributeSeed = (int)Random.Range(1, 4); //Higher bound is excluded

        int seed = (int)Random.Range(0f, 100f);

        if(tier == 0){ module.ModuleTier = "Common"; }
        else if(tier == 1){ module.ModuleTier = "Uncommon"; }
        else if(tier == 2){ module.ModuleTier = "Rare"; }
        else if(tier == 3){ module.ModuleTier = "Precious"; }
        else if(tier == 4){ module.ModuleTier = "Legendary"; }
        else if(tier == 5){ module.ModuleTier = "Cosmic"; }
        else if(tier == 6){ module.ModuleTier = "Godly"; }

        if(attributeSeed == 1) {module.ModuleValue = GenerateAtkModule(tier, seed); module.ModuleAttribute = "Attack";}
        else if(attributeSeed == 2) {module.ModuleValue = GenerateAtkSpdModule(tier, seed); module.ModuleAttribute = "Attack Speed";}
        else if(attributeSeed == 3) {module.ModuleValue = GenerateHPModule(tier, seed); module.ModuleAttribute = "HP";}

        if(moduleDeck != null) module.transform.SetParent(moduleDeck);
    }
}
