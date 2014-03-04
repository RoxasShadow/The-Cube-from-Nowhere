using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public  GameObject player;
	private Camera cam;

	public float x = 0;
	public float y = 0;
	public float z = 0;
	
	void Start() {
		cam = GetComponent<Camera>();
		SpawnPlayer();
	}

	private void SpawnPlayer() {
		Vector3 position = new Vector3 (x, y, z);
		cam.SetTarget ((Instantiate(player, position, Quaternion.identity) as GameObject).transform);
	}
}
