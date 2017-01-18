
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeSystem : MonoBehaviour {

	public GameObject Node;
	public int maxNodesOnScreen;

	public GameObject deathParticleEffect;
	GameManager manager;

	public float radius = 40;
	bool hasDied;
	public int level;

	//int lives; 		We thought about putting lives into the game. Isn't implemented yet.

	float c1;
	float c2;
	float s1;
	float s2;

	ArrayList Nodes = new ArrayList();
	
	void Start () {
		hasDied = false;
		manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
		//lives = 3;
		level = 2;

		c1 = Mathf.Cos (2 * Mathf.PI / 5);
		c2 = Mathf.Cos (Mathf.PI / 5);
		s1 = Mathf.Sin (2 * Mathf.PI / 5);
		s2 = Mathf.Sin (4 * Mathf.PI / 5);

		maxNodesOnScreen = 5;
		makeNodes();
		StartCoroutine("CheckDistance");
	}

	void makeNodes() {
		Nodes.Clear();
		while (maxNodesOnScreen >= 1) {

			Vector3 temp = new Vector3();
			switch (maxNodesOnScreen) {
				case 1:	temp = new Vector3(radius * -s1 - 10 + Random.value * 20, radius * c1 - 10 + Random.value * 20, 1);
						break;
				case 2:	temp = new Vector3(radius * 0 - 10 + Random.value * 20, radius * 1 - 10 + Random.value * 20, 1);
						break;
				case 3:	temp = new Vector3(radius * s1 - 10 + Random.value * 20, radius * c1 - 10 + Random.value * 20, 1);	
						break;
				case 4:	temp = new Vector3(radius * s2 - 10 + Random.value * 20, radius * -c2 - 10 + Random.value * 20, 1);
						break;
				case 5:	temp = new Vector3(radius * -s2 - 10 + Random.value * 20, radius * -c2 - 10 + Random.value * 200, 1);				
						break;
			}
			Nodes.Add((GameObject) Instantiate(Node, transform.position + temp, transform.rotation));
			maxNodesOnScreen--;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Enemy" && !hasDied) {
			hasDied = true;
			manager.PlayerDeath();
			Death();
		}

		level++;

		for (int i = 0; i < Nodes.Count; i++) {
			if (other.gameObject != (GameObject)Nodes[i])						//////////////// maybe change the gameobject cast. unity told me to do it.
				Destroy((GameObject)Nodes[i]);
			else Nodes.RemoveAt(i);
		}

		maxNodesOnScreen = 5;
		makeNodes();
	}

	void Death() {
		Instantiate(deathParticleEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}

	IEnumerator CheckDistance() {
		yield return new WaitForSeconds(4);

		for (int i = 0; i < Nodes.Count; i++ ) { 
			if (Vector3.Distance(((GameObject)(Nodes[i])).transform.position, transform.position) >= 200) {
				Debug.Log("Reset");
				for (int j = 0 ; j < Nodes.Count; j++) 
					Destroy((GameObject)Nodes[i]);
				makeNodes();
			}
		}
		StartCoroutine("CheckDistance");
	}
}






