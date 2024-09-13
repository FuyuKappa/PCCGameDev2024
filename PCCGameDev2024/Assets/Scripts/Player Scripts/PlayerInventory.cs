using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInventory
{
    [HideInInspector]
    public static List<Module> Inventory;
    
    private static void Awake(){
        Inventory = new();
    }

    public static void AddToInventory(Module m){
        Inventory.Add(m);
    }
}
