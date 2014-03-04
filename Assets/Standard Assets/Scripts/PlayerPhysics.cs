using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour {
	public  LayerMask   collisionMask;
	private BoxCollider boxCollider;
	private Vector3     size;
	private Vector3     center;
	private float       skin = .005f;
	
	[HideInInspector]
	public bool grounded;
	
	Ray        ray;
	RaycastHit hit;
	
	void Start() {
		boxCollider = GetComponent<BoxCollider>();
		size        = boxCollider.size;
		center      = boxCollider.center;
	}
	
	public void Move(Vector2 moveAmount) {
		float   deltaY   = moveAmount.y;
		float   deltaX   = moveAmount.x;
		Vector2 p        = transform.position;
		        grounded = false;
		
		for (int i = 0; i < 3; i ++) {
			float dir = Mathf.Sign(deltaY);
			float x = (p.x + center.x - size.x/2) + size.x/2 * i; // Left, centre and then rightmost point of collider
			float y = p.y + center.y + size.y/2 * dir;         // Bottom of collider
			
			ray = new Ray(new Vector2(x, y), new Vector2(0, dir));

			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask)) {
				float dst = Vector3.Distance (ray.origin, hit.point); // Get Distance between player and ground
				
				// Stop player's downwards movement after coming within skin width of a collider
				deltaY   = dst > skin ? dst * dir + skin : 0;
				grounded = true;
				break;
			}
		}

		// Check collisions left and right
		for (int i = 0; i < 3; i ++) {
			float dir = Mathf.Sign(deltaX);
			float x = p.x + center.x + size.x/2 * dir;
			float y = p.y + center.y - size.y/2 + size.y/2 * i;
			
			ray = new Ray(new Vector2(x, y), new Vector2(dir, 0));
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaX) + skin, collisionMask)) {
				float dst = Vector3.Distance (ray.origin, hit.point); // Get Distance between player and ground
				
				// Stop player's downwards movement after coming within skin width of a collider
				deltaX = dst > skin ? dst * dir - skin * dir : 0;

				break;
			}
		}
		
		transform.Translate(new Vector2(deltaX, deltaY));
	}
	
}
