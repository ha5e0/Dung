using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public float speed = 1.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		float hor = Input.GetAxis ("Horizontal");
		float ver = Input.GetAxis ("Vertical");
		
		Vector3 forwardDirection = Camera.main.transform.TransformDirection (Vector3.forward);
		forwardDirection.y = 0;
		forwardDirection.Normalize ();
		forwardDirection *= Input.GetAxis ("Vertical");
		
		Vector3 rightDirection = Camera.main.transform.TransformDirection (Vector3.right);
		rightDirection.y = 0;
		rightDirection.Normalize ();
		rightDirection *=Input.GetAxis ("Horizontal");

		GetComponent<Rigidbody>().MovePosition(transform.position + (forwardDirection + rightDirection) * speed * Time.deltaTime);

		
		if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0) transform.forward = Vector3.Normalize(forwardDirection + rightDirection);
		
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			GetComponent<Rigidbody>().AddForce(new Vector3(0,300.0f,0));
		}

		
		//Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//GetComponent<Rigidbody>().MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
	}
	
	void FixedUpdate() {
	}
}
