
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float angularVel = 200; 
	public float speed = 5; 
	
	void Update () {
		// Controls: WASD or Arrow Keys
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.forward, angularVel * Time.deltaTime);

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			transform.Rotate(Vector3.forward, -angularVel * Time.deltaTime);

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			Accelerate(speed);
	}
	
	void Accelerate (float a) {
		float tTheta = transform.rotation.eulerAngles.z + 90; // offset for local space
		transform.position += new Vector3(Mathf.Cos(tTheta * Mathf.Deg2Rad), Mathf.Sin(tTheta * Mathf.Deg2Rad), 0) * a * Time.deltaTime;
	}
}