using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float cam_speed;
	public float cam_rot_speed;
	
	public float smoothTime = 0.3F;
    private float Velocity = 10.0F;
	
	public GameObject Cam_Attachement;
	public Player_Physics_Controller player_Physics_Controller;
	
	private Vector3 new_Position;
	// Use this for initialization
	void Start () {
	new_Position = Cam_Attachement.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		new_Position = Cam_Attachement.transform.position;
		
		//new_Position.x = Mathf.SmoothDamp(transform.position.x, Cam_Attachement.transform.position.x, ref Velocity, smoothTime);
		//new_Position.y = Mathf.SmoothDamp(transform.position.y, Cam_Attachement.transform.position.y, ref Velocity, smoothTime);
		//new_Position.z = Mathf.SmoothDamp(transform.position.z, Cam_Attachement.transform.position.z, ref Velocity, smoothTime);
		
		
		transform.position = new_Position;
		//transform.rotation = Cam_Attachement.transform.rotation;
		//rigidbody.velocity =(Cam_Attachement.transform.position-transform.position)*cam_speed;
		transform.LookAt(player_Physics_Controller.transform, player_Physics_Controller.current_normal);
		//transform.rotation = Quaternion.LookRotation(player_Physics_Controller.rigidbody.velocity,player_Physics_Controller.current_normal);
	}
}
