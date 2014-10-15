using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {
    public Transform target;
    void Update() {
		
		Vector3 relativepos = (target.position - transform.position);
        transform.rotation = Quaternion.LookRotation(relativepos, new Vector3(0,0,1));
		transform.Rotate(90f,0f,0f);
		
		
    }
}