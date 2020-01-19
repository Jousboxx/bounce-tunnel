using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
	void OnTriggerEnter(Collider other){
		DeathMenu.isDead = true;
	}
}
