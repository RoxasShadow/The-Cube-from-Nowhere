using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
	void OnTriggerEnter(Collider c) {
		print ("1COLLIDED!!!!111");
	}
	void onTriggerEnter2D(Collider2D c) {
		print ("2COLLIDED!!!!111");
	}
	void OnCollision2DEnter(Collision2D c) {
		print ("3COLLIDED!!!!111");
	}
	void OnCollisionEnter(Collision c) {
		print ("4COLLIDED!!!!111");
	}
}
