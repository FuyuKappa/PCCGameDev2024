using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
	public GameObject prefab;
	public Transform spawnPoint;
	
	
    private void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("Player")){
			Instantiate(prefab, spawnPoint);
			Destroy(other.gameObject);
		}
		
		
		
		/*other.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);*/
	}
	private void OnTriggerExit(Collider other){
		if(other.gameObject.CompareTag("Player")){
			print("You have left");
		}
		
	}
	private void OnTriggerStay(Collider other){
		if(other.gameObject.CompareTag("Player")){
			print("You are hitting me!");
		}
	}
}
