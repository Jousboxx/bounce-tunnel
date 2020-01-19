using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
	private Vector3 impulse;
	public int Blast;

	private Quaternion BouncepadRotation;
	//private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
		//Set BouncepadRotation to the rotation of this Bouncepad
		BouncepadRotation = transform.rotation;

		//Set impulse to the unit vector normal to the Bouncepad face multiplied by Blast
		impulse = (BouncepadRotation * Vector3.forward * Blast);
		//camera = Camera.main;
	}
	
	void OnTriggerEnter(Collider other){

		other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
		//camera.GetComponent<CABounce>().Bounced();
	}
}
