using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncePad : MonoBehaviour
{
	private Vector3 impulse;
	public int blast;
    // Start is called before the first frame update
    void Start()
    {
		var xAngle = transform.eulerAngles.x * (Mathf.PI/180);
		var yAngle = transform.eulerAngles.y * (Mathf.PI/180);
		var zAngle = transform.eulerAngles.z * (Mathf.PI/180);

		impulse = new Vector3(Mathf.Sin(zAngle) * -1 * blast, Mathf.Cos(xAngle + zAngle) * blast, Mathf.Sin(xAngle) * blast);
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	void OnTriggerEnter(Collider other){
		other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
		print("entered");
	}
}
