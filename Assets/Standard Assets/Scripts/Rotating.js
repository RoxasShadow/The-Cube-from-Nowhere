#pragma strict

var speed = 300;

function Update () {
	transform.Rotate(Vector3.back * speed * Time.deltaTime, Space.World);
}