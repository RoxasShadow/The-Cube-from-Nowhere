using UnityEngine;
using System.Collections;

public class Deity : MonoBehaviour {
	public  GameObject terrain;
	public  GameObject star;
	
	void Update() {
		if (isMaking())
			generate();
	}

	bool isMaking() {
		bool make = false;
		foreach (Touch e in Input.touches)
			if(e.phase == TouchPhase.Ended)
				if(e.tapCount == 1) {
					make = true;
					break;
				}
		return Input.GetButtonDown ("Make") || make;
	}

	private void generate() {
		float x = transform.position.x + 10;
		float y = transform.position.y + 10;
		float z = transform.position.z + 10;
		Vector3 terrainPosition = new Vector3 (Random.Range (x - 10, x + 10), Random.Range (-10, y), z);
		Vector3 starPosition    = new Vector3 (Random.Range (x - 10, x + 10), Random.Range (-10, y), z);

		Instantiate (terrain, terrainPosition, Quaternion.identity);
		Instantiate (star,    starPosition,    Quaternion.identity);
	}
}
