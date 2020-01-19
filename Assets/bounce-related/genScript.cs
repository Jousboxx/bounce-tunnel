using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genScript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject toSpawn;
	public GameObject me;
	public int numSpawned;
	private int secondarySpawnRange = 20;
	

    // This script will simply instantiate the Prefab when the game starts.
    void Start(){
    }
	//unneeded change
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "PlayerBall"){		
			this.organizedSpawning();
			for (int i = 0 ; i < 2; i++){
				for (int j = 0 ; j < 2 ; j++){
					for (int k = 0 ; k < 2 ; k++){
						GameObject obj = Instantiate(me, new Vector3(transform.position.x - secondarySpawnRange + i*secondarySpawnRange*2, 
						transform.position.y - secondarySpawnRange + j*secondarySpawnRange*2, 
						transform.position.y - secondarySpawnRange + k*secondarySpawnRange*2), Quaternion.identity);
						obj.GetComponent<Collider>().enabled = false;
						obj.GetComponent<Collider>().enabled = true;
					}
				}
			}
		} 
	}
	
	void organizedSpawning(){
		Vector3 newCenter = new Vector3(transform.position.x + Random.Range(5.0f,15.0f),
		transform.position.y + Random.Range(5.0f,15.0f), transform.position.y + Random.Range(5.0f,15.0f));
		for (int x = 0 ; x < numSpawned ; x++){
			Vector3 newSpawnLoc = new Vector3(newCenter.x + Random.Range(-15.0f, 15.0f), 
			newCenter.y + Random.Range(-15.0f, 15.0f), newCenter.z + Random.Range(-15.0f, 15.0f));
			Instantiate(toSpawn, newSpawnLoc, Quaternion.LookRotation(newSpawnLoc, newCenter));
		}
	}
}
