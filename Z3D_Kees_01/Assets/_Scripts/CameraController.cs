using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float cam_speed;
	public float cam_rot_speed;
	
	public float smoothTime = 0.3F;
	public float smoothingNormal = 0.95f;
	public float smoothingPosition = 0.95f;
    private float Velocity = 10.0F;
	
	private Vector3 V1;
	private Vector3 V2;
	private Vector3 V3;
	private Vector3 V4;
	private Vector3 V5;
	private Vector3 VFinal;
	
	private Vector3 smoothNormal = Vector3.zero;
	
	public GameObject Cam_Attachement;
	public Player_Physics_Controller player_Physics_Controller;
	
	private Vector3 new_Position;
	
	// Update is called once per frame
	void Update () {
		if(Cam_Attachement != null && player_Physics_Controller != null){
			V1=V2;
			V2=V3;
			V3=V4;
			V4=V5;
			V5 = Cam_Attachement.transform.position;
			
			VFinal=(V1+V2+V3+V4+V5)/5f;
			
			smoothNormal = smoothingNormal * smoothNormal + (1f - smoothingNormal) * player_Physics_Controller.current_normal;
			
			//transform.position = Cam_Attachement.transform.position;
			transform.position = Cam_Attachement.transform.position * (1f - smoothingPosition) + smoothingPosition * transform.position;
			//transform.rotation = Cam_Attachement.transform.rotation;
			//rigidbody.velocity =(Cam_Attachement.transform.position-transform.position)*cam_speed;
			transform.LookAt(player_Physics_Controller.transform, smoothNormal);
			//transform.rotation = Quaternion.LookRotation(player_Physics_Controller.rigidbody.velocity,player_Physics_Controller.current_normal);
		}
	}

	public void associate(GameObject go, Player_Physics_Controller phys){
		Cam_Attachement = go;
		player_Physics_Controller = phys;
		V1 = Cam_Attachement.transform.position;
		V2 = Cam_Attachement.transform.position;
		V3 = Cam_Attachement.transform.position;
		V4 = Cam_Attachement.transform.position;
		V5 = Cam_Attachement.transform.position;
	}
}
