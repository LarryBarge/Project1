using UnityEngine;
using System.Collections;

public class BrickScript : MonoBehaviour {
	public int pointValue = 1;
	public int hitPoints = 1;
	
	static int numBricks = 0;
	
	// Use this for initialization
	void Start () {
		numBricks++;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision col){
		hitPoints--;
		
		if(hitPoints <= 0){
			Die();
		}
		
		
		
	}
	
	
	void Die(){
		Destroy(gameObject);
		GameObject.Find("Paddle").GetComponent<PaddleScript>().AddPoint(pointValue);
		numBricks--;
		Debug.Log(numBricks);
		
		if(numBricks <= 0){
			//Load new level
		
		}
	}
}
