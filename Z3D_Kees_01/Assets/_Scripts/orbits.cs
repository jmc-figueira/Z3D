    using UnityEngine;
    using System.Collections;
     
    public class orbits : MonoBehaviour {
     
    public GameObject cent;
	public float rotationSpeed;
	
	
    private Transform center;
    private Vector3 axis;
	
    
    void Start () {
	
	
    center = cent.transform;
	
	//random orbit rotation
    axis = Random.insideUnitSphere;
	
    }
     
    void Update () {  //apperantly works smoother when using FixedUpdate
	transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);
    }
	
    }
	
	
	