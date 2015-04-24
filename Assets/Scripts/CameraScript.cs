using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public float LookSpeed = 5.0f;
	public float ZoomZpeed = 5.0f;
	public float ScrollSpeed = 1.0f;
	public bool ScrollOnEdge = false;
	public float ScrollEdge = 0.01f;
	public float ScrollEdgeSpeed = 15.0f;

	Vector2 lastMousePos;

	// Use this for initialization
	void Start () {
		lastMousePos = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 mousePos = Input.mousePosition;
		if ( Input.GetKey("mouse 1") )
		{
			transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed * (lastMousePos.x-mousePos.x), Space.Self);
			Vector3 fwd = transform.forward;
			fwd.y = 0;
			fwd.Normalize();
			transform.Translate(fwd * Time.deltaTime * ScrollSpeed * (lastMousePos.y-mousePos.y), Space.World);
			
		}
		if ( Input.GetKey("mouse 2") )
		{
			transform.Rotate(Vector3.down * Time.deltaTime * LookSpeed * (lastMousePos.x-mousePos.x), Space.World);
			transform.Rotate(Vector3.right * Time.deltaTime * LookSpeed * (lastMousePos.y-mousePos.y), Space.Self);
		}
		lastMousePos = mousePos;

		transform.Translate (Vector3.forward * ZoomZpeed * Input.GetAxis ("Mouse ScrollWheel"), Space.Self);

		if (ScrollOnEdge) {
			if (Input.GetKey ("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge)) {
				transform.Translate (Vector3.right * Time.deltaTime * ScrollEdgeSpeed, Space.Self);
			} else if (Input.GetKey ("a") || Input.mousePosition.x <= Screen.width * ScrollEdge) {
				transform.Translate (Vector3.right * Time.deltaTime * -ScrollEdgeSpeed, Space.Self);
			}
		
			if (Input.GetKey ("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge)) {
				Vector3 fwd = transform.forward;
				fwd.y = 0;
				fwd.Normalize ();
				transform.Translate (fwd * Time.deltaTime * ScrollEdgeSpeed, Space.World);
			} else if (Input.GetKey ("s") || Input.mousePosition.y <= Screen.height * ScrollEdge) {
				Vector3 fwd = transform.forward;
				fwd.y = 0;
				fwd.Normalize ();
				transform.Translate (fwd * Time.deltaTime * -ScrollEdgeSpeed, Space.World);
			}
		}
	}
}
