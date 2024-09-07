using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
	/*
	//Since we want to handle collisions, we don't need these
    // Start is called before the first frame update
    void Start()
    {
        
    }
	
	//For physics simulation, so that it's not physics dependent
	private void FixedUpdate(){
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	*/
	
	private void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Player")){
			print("You hit me!");
		}

		collision.rigidbody.AddForce(Vector3.up * 20, ForceMode.Impulse);
	}
	private void OnCollisionExit(Collision collision){
		if(collision.gameObject.CompareTag("Player")){
			print("You have left");
		}
		
	}
	private void OnCollisionStay(Collision collision){
		if(collision.gameObject.CompareTag("Player")){
			print("You are hitting me!");
		}
	}
}
