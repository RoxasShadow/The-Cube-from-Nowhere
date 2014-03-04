using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour {
	public  float   gravity      = 20;
	public  float   speed        = 8;
	public  float   acceleration = 30;
	public  float   jumpHeight   = 12;

	private float   currentSpeed;
	private float   targetSpeed;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	
	void Start() {
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	void Update() {
		targetSpeed  = getHorizontalMovement() * speed;
		currentSpeed = PhysicsUtils.IncrementTowards(currentSpeed, targetSpeed, acceleration);
		
		if (playerPhysics.grounded) {
			amountToMove.y = 0;

			if (isJumping())
				amountToMove.y = jumpHeight;
		}
		
		amountToMove.x  = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move(amountToMove * Time.deltaTime);
	}

	float getHorizontalMovement() {
		if (Input.touches.Length > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			return touchDeltaPosition.x;
		}
		else
			return Input.GetAxisRaw("Horizontal");
	}

	bool isJumping() {
		bool jump = false;
		foreach (Touch e in Input.touches)
			if(e.phase == TouchPhase.Ended)
				if(e.tapCount == 1) {
					jump = true;
					break;
				}
		return Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical") || jump;
	}
}
