using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	private float      trackSpeed = 10;
	public  Transform  target;

	public void SetTarget(Transform t) {
		target = t;
	}

	void LateUpdate() {
		if (target) {
			float x = PhysicsUtils.IncrementTowards (transform.position.x, target.position.x, trackSpeed);
			float y = PhysicsUtils.IncrementTowards (transform.position.y, target.position.y, trackSpeed);
			transform.position = new Vector3 (x, y, transform.position.z);
		}
	}
}
