public float speedUp = 1.5f;
private float speedTimer;

public float slowDown = 0.5f;
private float slowTimer;

	
	void fixedUpdate(){
	
	if(slowTimer > 0){
	  slowTimer = slowTimer - Time.fixedDeltaTime; 
	 if (slowTimer <= 0){
		speed = speed/slowDown;
		}
	}
		
	if(speedTimer > 0){
	  speedTimer = speedTimer - Time.fixedDeltaTime; 
	 if (speedTimer <= 0){
		speed = speed/speedUp;
		}
	}

}

/*
SPEEDUP


*/
void OnTriggerEnter(Collider other){
				
				//"player" tag should be proper
				if (other.gameObject.tag == "speedUp") {
				
					//sets timer and speed
					speedTimer = 3f;
					speed = speed * speedUp;
					
					other.gameObject.SetActive(false);
					Destroy (other.gameObject);
					Debug.Log("collision detected");
					}
				
			
			
		
}

/*
SLOWDOWN


*/
void OnTriggerEnter(Collider other){
				
				//"player" tag should be proper
				if (other.gameObject.tag == "slowDown") {
				
					//Sets timer and speed
					slowTimer = 3f;  
					speed = speed * slowDown;
					
					other.gameObject.SetActive(false);
					Destroy (other.gameObject);
					Debug.Log("collision detected");
					}
				
			
			
		
}
					