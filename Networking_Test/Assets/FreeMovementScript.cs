using UnityEngine;
using System.Collections;

public class FreeMovementScript : MonoBehaviour {
	public float speed;

	void FixedUpdate(){
		if (networkView.isMine) {
			float horizontalComponent = Input.GetAxis ("Horizontal");
			float verticalComponent = Input.GetAxis ("Vertical");
			Vector3 movement = new Vector3 (horizontalComponent, 0.0f, verticalComponent);
			rigidbody.AddForce (movement * speed * Time.deltaTime);
		}
		else{
			enabled = false;
		}
	}
}
