
using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject player;
	/*int lives;
								Add lives into game.
	void Start() {
		lives = 3;
	}*/
	
	void Update() {
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}

	public void PlayerDeath() {
 		Debug.Log("Dead");
		//lives--;
		StartCoroutine("Restart");
	}

	IEnumerator Restart() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		int len = enemies.Length;
		for (int i = 0; i < len; i++) 
			Destroy(enemies[i].gameObject);

		Camera.main.GetComponent<CameraFollow>().target = Camera.main.transform;

		yield return new WaitForSeconds(2);
		Application.LoadLevel("MasterGameScene");
	}
}
