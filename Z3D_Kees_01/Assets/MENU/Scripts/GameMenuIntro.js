#pragma strict
//spd is the starting speed of the camera
var spd : int = 50;

function Start () {
}

function Update() {
		// Move the object forward along its z axis 1 unit/second.
		transform.Translate(Vector3.forward * Time.deltaTime*spd);
		//update speed
		if (spd > 0) {
			spd = spd - 1;
		}
	}