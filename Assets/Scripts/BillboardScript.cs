using UnityEngine;
using System.Collections;

public class BillboardScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate () {
		transform.LookAt(Camera.main.transform.position, -Vector3.up);
		
	}
}
