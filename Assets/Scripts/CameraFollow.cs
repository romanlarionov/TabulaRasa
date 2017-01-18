
using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	Vector2 velocity = new Vector2(0.5f, 0.5f);
	Vector3 myPos;

	void Update() {
		myPos = transform.position;
		float xNewPosition = Mathf.SmoothDamp(myPos.x, target.position.x, ref velocity.x, smoothTime);
		float yNewPosition = Mathf.SmoothDamp(myPos.y, target.position.y, ref velocity.y, smoothTime);
		transform.position = new Vector3(xNewPosition, yNewPosition, myPos.z);
	}
}
