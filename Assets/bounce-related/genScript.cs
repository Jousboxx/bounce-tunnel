using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class genScript : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject toSpawn;

	//Thing to spawn more of (set to this object in Unity)
	public GameObject me;

	//number of toSpawn to spawn
	public int numToSpawn;

	//Controls XY distance from genBox bouncepads spawn
	public float SpawnRadius;

	//Controls Z distance from genBox bouncepads spawn (should be set to half of the genBox box collider size)
	public float SpawnLength;

	//How far forward genBoxes spawn bounce pads
	public float preSpawnDistance;

    // This script will simply instantiate the Prefab when the game starts.
    void Start(){
    }
	
	//when the collision is hit
	void OnTriggerEnter(Collider other){
		//to make sure its only the player that activates
		if (other.gameObject.name == "PlayerBall"){		
			this.organizedSpawning();

			//Creates a new genBox further forward
			GameObject obj = Instantiate(me, new Vector3(transform.position.x, transform.position.y, transform.position.z + 25), Quaternion.identity); 

			//breaks without this sometimes, it sometimes initializes with the collider not like we want it
			obj.GetComponent<Collider>().enabled = false;
			obj.GetComponent<Collider>().enabled = true;
            }
		} 
	
	void organizedSpawning(){

		Vector3 Center = transform.position;
		print("Spawn center is " + Center);
		
		//One iteration for each new bouncepad to spawn
		for (int j = 0; j < numToSpawn; j++){
			
			//Generate a random angle to determine where we spawn the next p
			float RandomAngle = Random.Range(0.0f, 360.0f);

			//Convert the angle to x/y coords, add a bit of random variation
			float NextX = Mathf.Cos(RandomAngle) * SpawnRadius + Random.Range(-2.0f, 2.0f);
			float NextY = Mathf.Sin(RandomAngle) * SpawnRadius + Random.Range(-2.0f, 2.0f);;

			//Random value within the range for Z
			float NextZ = Random.Range(-SpawnLength, SpawnLength) + Center.z + preSpawnDistance;

			//Convert the location to a vector
			Vector3 newSpawnLoc = new Vector3(NextX, NextY, NextZ);
			print("spawning a pad at " + newSpawnLoc);

			

			//This creates a new instance of the toSpawn at the newSpawnLoc with the angle that makes it face from where it is to the newCenter

			//Get the vector pointing from the new spawn location toward the genBox
			Vector3 newSpawnRot = Quaternion.LookRotation(newSpawnLoc, Center).eulerAngles;

			//X rotation should always be 0 so pads spawn parallel to the direction of motion
			newSpawnRot.x = 0;

			//Since the player is moving in the positive Z direction, we don't really care about the Y axis rotation and we can use to to create a more randomized look.
			newSpawnRot.y = 0; //Random.Range(0.0f, 360.0f);

			///Z rotation remains untouched to ensure the bounce pads point inward

			//Instantiate a new bounce pad
			Instantiate(toSpawn, newSpawnLoc, Quaternion.Euler(newSpawnRot));
		}
	}
}

