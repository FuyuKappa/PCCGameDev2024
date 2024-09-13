using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    private BoxCollider PickUpBounds;
    private List<GameObject> ItemsInRange;

    // Start is called before the first frame update
    void Start()
    {
        PickUpBounds = GetComponentInChildren<BoxCollider>();
        ItemsInRange = new();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("ItemPickup")){
            ItemsInRange.Add(other.gameObject);
            PrintCurrentInRange();
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("ItemPickup")){
            ItemsInRange.Remove(other.gameObject);
            PrintCurrentInRange();
        }
    }

    private void PrintCurrentInRange(){
        foreach(GameObject current in ItemsInRange){
            print(current.GetComponent<Module>().GetStats());
        }
    }
}
