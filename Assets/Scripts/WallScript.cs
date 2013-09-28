using UnityEngine;
using System.Collections;

public class WallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/*void OnCollisionEnter(Collision col){
		foreach(ContactPoint contact in col.contacts){
			if (contact.thisCollider == collider)
			{
				//This is the paddles contact point
				float english = contact.point.x - transform.position.x;
				
				contact.otherCollider.rigidbody.AddForce(0, 30 * english * 2, 0);
				//rigidbody.AddForce(200,1000f,0);
			}
		}
	}*/
}
