using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	#region [initialization]
	//Public Variables
	public float speed;
	public float rot_speed;
	public float temp_counter_init;
	public float Gap_Counter_init;
	public float Gap_Width_init;
	
	public Text Debugger;
	public GameObject Tail;
	public GameController gameController;
	public  Player_Physics_Controller PlayerPhysics;
	//Private Variables
	
	private float temp_counter;
	private float gap_counter;
	private float gap_width;
	private Vector3 rot_vector;
	public Vector3 previous_normal;
	public Vector3 current_normal = new Vector3(0f,1f,0f);

	#endregion
	
	// Use this for initialization
	void Start () {
		gap_counter = Gap_Counter_init;
		gap_width = 0f;
		rigidbody.freezeRotation = false;
		previous_normal = new Vector3(0f,0.1f,0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(networkView.isMine){
			//This is the freeze option controlled by gameController
			//if(gameController.Freeze_Counter==0f){
			
			/*#region [rotation]
			//the yaw of the ball is adjusted
			rot_vector = new Vector3(0f,Input.GetAxis("Horizontal") * (Time.deltaTime * rot_speed),0f);
			transform.rotation *= Quaternion.Euler(rot_vector);
			#endregion

			#region [velocity]
			//Movement in direction of the object
			Vector3 AddPos = transform.rotation * Vector3.forward;
			transform.position += AddPos * speed*Time.fixedDeltaTime;
			//rigidbody.velocity = AddPos * speed*Time.fixedDeltaTime;
			#endregion*/
			
			transform.position = PlayerPhysics.transform.position;
			
			#region [Tail Creation]
			if(temp_counter==Mathf.Ceil(temp_counter_init*speed*speed)){
				temp_counter=0f;
				//if new block must be drawn
				if(gap_width ==0f){
					//if not drawing a gap
					if(gap_counter==0f){
						//start drawing new gap
						gap_counter=Gap_Counter_init;
						gap_width = Gap_Width_init;
					}else{
						//draw normal block
						Network.Instantiate(Tail, transform.position, transform.rotation, 0);
						gap_counter--;
					}
				}else{
				//if drawing a gap keep doing it
					gap_width--;
				}
			}else{
				//if no new block must be drawn
				temp_counter++;	
			}
			
			
			
			#endregion
			//}
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Tail"){
			//if colliding with an object with label "Tail" set freezecounter
			Debug.Log("died");
		}
	}
	
	/*void OnCollisionEnter(Collision collision) {
		current_normal = collision.contacts[0].normal;
		if(previous_normal != current_normal){
			transform.rotation.SetFromToRotation(new Vector3(0f,0f,0f), new Vector3(0f,1f,0f));
			Debug.Log(previous_normal);
			previous_normal = current_normal;
			//ContactPoint contact = collision.contacts[0];
			//Vector3 pos = contact.point;}
			//transform.position = new Vector3(transform.position.x,  contact.point.y+0.7f, transform.position.z);
		}
	}*/
}
