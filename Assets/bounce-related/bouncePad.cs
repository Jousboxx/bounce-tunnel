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
	//private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
		//Set BouncepadRotation to the rotation of this Bouncepad
		BouncepadRotation = transform.rotation;
	}
	
	void OnTriggerEnter(Collider other){
		
		//Set BouncepadRotation to the rotation of this Bouncepad
		
		PlayerRotation = other.transform.rotation;

		//Set impulse to the unit vector normal to the Bouncepad face multiplied by Blast	
		impulse1 = (PlayerRotation * Vector3.forward * (Blast/2));
		impulse2 = (BouncepadRotation * Vector3.forward * Blast);
		print("triggered " + (impulse1 + impulse2));	
		other.GetComponent<Rigidbody>().AddForce(impulse1, ForceMode.Impulse);
		//other.GetComponent<Rigidbody>().AddForce(impulse2, ForceMode.Impulse);
		//camera.GetComponent<CABounce>().Bounced();
	}
}
