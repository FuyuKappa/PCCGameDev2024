using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HitController : MonoBehaviour
{   
    [SerializeField]
    private PlayerAttack pa;
    private BoxCollider weaponBounds;

    // Start is called before the first frame update
    void Start()
    {
        //pa = transform.parent.parent.GetComponent<PlayerAttack>();
        weaponBounds = GetComponent<BoxCollider>();  
    }

    public void OnTriggerEnter(Collider other){
        if(!other.gameObject.CompareTag("Untagged")){
            print("Detected someone");
            print(other.gameObject.tag);
            pa.HandleHit(other);
        }
    }
}
