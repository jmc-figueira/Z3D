using UnityEngine;
using System.Collections;

public class Player_Physics_Controller : MonoBehaviour {
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncStartPosition = Vector3.zero;
	private Vector3 syncEndPosition = Vector3.zero;

	public float speed;
	public float rot_speed;
	public float Gravity_Strength;

	private float collision_counter_test;

	public GameController gameController;
	public PlayerController playerController;
	
	//Private Variables
	private Vector3 rot_vector;
	public Vector3 previous_normal;
	public Vector3 current_normal = new Vector3(0f,1f,0f);

	
	// Use this for initialization
	void Start () {
		previous_normal = new Vector3(0f,1f,0f);
		collision_counter_test=0f;
	}
	
	// Update is called once per frame
void FixedUpdate () {
		//This is the freeze option controlled by gameController
		//if(gameController.Freeze_Counter==0f){
		if(networkView.isMine){
			#region [rotation]

			transform.rotation = Quaternion.LookRotation(rigidbody.velocity,current_normal);
			rot_vector = new Vector3(0f,Input.GetAxis("Horizontal") * (Time.deltaTime * rot_speed),0f);
			transform.rotation *= Quaternion.Euler(rot_vector);

			playerController.transform.rotation = transform.rotation;
			#endregion

			#region [velocity]
			//Movement in direction of the object
			Vector3 AddPos = transform.rotation * Vector3.forward;
			//transform.position += AddPos * speed*Time.fixedDeltaTime;
			//transform.position += previous_normal*-0.05f;
			rigidbody.velocity = AddPos * speed*Time.fixedDeltaTime;
			rigidbody.AddForce(current_normal*-Gravity_Strength);
			#endregion
			//}
		}
		/*else{
			syncTime += Time.deltaTime;
			rigidbody.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
		}*/
	}

	/*void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info){
		Vector3 syncPosition = Vector3.zero;
		Vector3 syncVelocity = Vector3.zero;
		if (stream.isWriting)
		{
			syncPosition = rigidbody.position;
			stream.Serialize(ref syncPosition);
			
			syncVelocity = rigidbody.velocity;
			stream.Serialize(ref syncVelocity);
		}
		else
		{
			stream.Serialize(ref syncPosition);
			stream.Serialize(ref syncVelocity);

			syncTime = 0f;
			syncDelay = Time.time - lastSynchronizationTime;
			lastSynchronizationTime = Time.time;
			
			syncEndPosition = syncPosition + syncVelocity * syncDelay;
			syncStartPosition = rigidbody.position;
		}
	} */
	
	void OnCollisionStay(Collision collision) {
		current_normal = collision.contacts[0].normal;
	}
}
