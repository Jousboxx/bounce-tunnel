using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
	private Vector3 impulse1;
	private Vector3 impulse2;
	public int Blast;

	private Quaternion PlayerRotation;
	private Quaternion BouncepadRotation;

    // Start is called before the first frame update
    void Start()
    {
		//Set BouncepadRotation to the rotation of this Bouncepad
		BouncepadRotation = transform.rotation;
		//Set impulse to the unit vector normal to the Bouncepad face multiplied by Blast
		impulse1 = (BouncepadRotation * Vector3.forward * Blast);

	}

	void OnTriggerEnter(Collider other){

		//Get the player's rotation
		PlayerRotation = other.transform.rotation;

		//Consider the player's direction and give them a little boost forward	
		impulse2 = (PlayerRotation * Vector3.forward * (Blast/2));

		//Apply impulse to player's rigid body
		other.GetComponent<Rigidbody>().AddForce((impulse1 + impulse2), ForceMode.Impulse);

		Vector3 temp = (impulse1 + impulse2);
		print("Applying impulse of magnitude " + temp.magnitude);
	}
	
}
