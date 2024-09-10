using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAnimation : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack(){
        if(anim != null){
            anim.Play("Base Layer.SwordSwingFromRight", 0 , 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
