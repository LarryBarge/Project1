using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {
	
	public float paddleSpeed = 10f;
	public GameObject ballPrefab;
	int lives = 4;
	
	GameObject attachedBall = null;
	GUIText guiLives;
	
	int score = 0;
	
	public GUISkin scoreBoardSkin;
	
	
	// Use this for initialization
	void Start () {
		//Instantiate a new ball
		
		guiLives = GameObject.Find("GUI Lives").GetComponent<GUIText>();
		SpawnBall();
		
	}
	
	public void AddPoint(int v){
		score += v;
		
	}
	
	public void SpawnBall(){
		//Spawn/Instantiate new ball
		
		
		
		if(ballPrefab == null){
			Debug.Log("You forgot to link the ball prefab in the link");
			return;
		}
		
		
		
		attachedBall = (GameObject)Instantiate(ballPrefab);
		
		
		guiLives.text = "Lives: " + lives;
		
		lives --;
	}
	
	void OnGUI(){
		
		GUI.skin = scoreBoardSkin;
		GUI.Label(new Rect(0,10,100,100),"Score " + score );
			
	}
	
	// Update is called once per frame
	void Update () {
		
		//Checking input to see if pressed left
		transform.Translate(paddleSpeed * Time.deltaTime * Input.GetAxis("Horizontal"),0,0);
		
		if(transform.position.x > 7.4f){
			transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
		}
		if(transform.position.x < -7.4f){
			transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
		}
		
		if(attachedBall){
			Rigidbody ballRigidbody = attachedBall.rigidbody;
			ballRigidbody.position = transform.position + new Vector3(0,.75f,0);
			
			if(Input.GetButtonDown("Jump")){
				//Fire the ball
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(300f * Input.GetAxis("Horizontal"),1000f,0);
				
				attachedBall = null;
			}
			
		}
		
		
		
		
	}
	
	void FixedUpdate(){
		
	}
	
	//Look at different update functions to fix lag of ball vs physics motion.
	
	void OnCollisionEnter(Collision col){
		foreach(ContactPoint contact in col.contacts){
			if (contact.thisCollider == collider)
			{
				//This is the paddles contact point
				float english = contact.point.x - transform.position.x;
				
				contact.otherCollider.rigidbody.AddForce(300 * english, 0, 0);
				//rigidbody.AddForce(200,1000f,0);
			}
		}
	}
}
