
using UnityEngine;
using System.Collections;

public class SpecialNode : MonoBehaviour {
	
	public GameObject particle2;
	public GameObject OutWind;
	
	private ScoreScript scorescript;
	
	public GameObject ParticleEffect1;
	public GameObject ParticleEffect2;
	public int numParticleEffects;
	
	public float numSpawned;
	public float enemyRadius;
	
	bool found;
	bool hasFired = false;
	
	float c1;
	float c2;
	float s1;
	float s2;

	GameObject player;
	public GameObject Enemy;
	
	void Awake () {
		numSpawned = 2;
		scorescript = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreScript>();
		player = GameObject.FindGameObjectWithTag("Player");
		found = false;
		
		c1 = Mathf.Cos (2 * Mathf.PI / 5);
		c2 = Mathf.Cos (Mathf.PI / 5);
		s1 = Mathf.Sin (2 * Mathf.PI / 5);
		s2 = Mathf.Sin (4 * Mathf.PI / 5);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((other.gameObject.tag == "Player") && !hasFired) {
			StartCoroutine("ParticlePlay");
			
			SpawnEnemies();
			DestroyNearbyEnemies();
			hasFired = true;

			if (!found) {
				scorescript.StartScore();
				found = true;
			}
		}
	}

	void DestroyNearbyEnemies() {
		StartCoroutine("DeathAnimation");
	}

	IEnumerator ParticlePlay() {
		int choice = (int)Mathf.Floor (Random.value * numParticleEffects);
		GameObject temp;

		if ((choice == 1) && (ParticleEffect2 != null))
			temp = ParticleEffect2;
		else temp = ParticleEffect1;

		temp = (GameObject)Instantiate(temp, transform.position, transform.rotation);
		temp.transform.parent = this.transform;

		Destroy(this.transform.FindChild("wind").gameObject);
		
		GameObject temp2 = (GameObject)Instantiate(OutWind, transform.position, transform.rotation);
		temp2.transform.parent = this.transform;
		
		yield return new WaitForSeconds(1);
		
		Destroy (this.transform.FindChild("outWind(Clone)").gameObject);
		
		yield return new WaitForSeconds(5);
		
		Destroy (this.gameObject);
	}
	
	void SpawnEnemies() {
		numSpawned = player.GetComponent<NodeSystem>().level;
		
		for (int i = 0; i < numSpawned; i++) {
			float tempRadius = enemyRadius;
			if (Mathf.Floor(i / 5) > 0)
				tempRadius = enemyRadius * Mathf.Floor (i / 5);

			float tempX = 0, tempY = 0;
			switch (i % 5) {
				case 0:	tempX = tempRadius * -s1; tempY = tempRadius * c1;
						break;
				case 1:	tempX = 0; tempY = tempRadius;
						break;                              
				case 2:	tempX = tempRadius * s1; tempY = tempRadius * c1;
						break;
				case 3:	tempX = tempRadius * s2; tempY = tempRadius * -c2;
						break;
				case 4:	tempX = tempRadius * -s2; tempY = tempRadius * -c2;
						break;
			}
			Instantiate(Enemy, transform.position + new Vector3(tempX, tempY, 1), transform.rotation);
		}
	}

	IEnumerator DeathAnimation() {
		yield return new WaitForSeconds(0.5f);

		if (player) { 
			Collider2D[] cols = Physics2D.OverlapCircleAll(player.transform.position, 20);
			int len = cols.Length;
			for (int i = 0; i < len; i++) {
				if (cols[i].gameObject.tag == "Enemy"){
					scorescript.AddScore(50);
					cols[i].gameObject.GetComponent<EnemyBehavior>().Kill();
				}
			}
		}
	}
}












