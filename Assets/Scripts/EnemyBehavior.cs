
using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	private GameObject player;
	private float maxDistance = 1f;
	
	public float angularVel;
	public float speed;

	public GameObject EnemyDeathParticle;
	Vector3 playerPos;
	Vector3 myPos;
	
	void Start() {
		angularVel = 90;
		speed = 10;
		player = GameObject.FindGameObjectWithTag("Player"); 
	}
	
	void Update() {
		playerPos = player.transform.position;
		myPos = transform.position;
		
		Vector3 direction = playerPos - myPos;
		direction.y = 0;	// 2D game.

		// Rotate to face player.
		rigidbody2D.transform.eulerAngles = new Vector3(0,0,Mathf.Atan2((playerPos.y - myPos.y), (playerPos.x - myPos.x)) * Mathf.Rad2Deg - 90);

		// If within 20 units & not touching player, move forward. 
		if ((direction.magnitude <= 20) && (direction.magnitude > maxDistance)) 
			transform.position += speed * Time.deltaTime * transform.up;
		
		// If really far away, destroy enemy. Save memory.
		if(direction.magnitude >= 500) {
			Destroy(this.gameObject);
		}
	}

	public void Kill() {
		Instantiate(EnemyDeathParticle, myPos, transform.rotation);
		Destroy(this.gameObject);
	}
}


