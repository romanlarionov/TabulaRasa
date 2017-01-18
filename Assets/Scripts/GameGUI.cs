
using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Texture gameScore;
	public Texture gameCombo;
	public Texture gameMulti;
	public GUISkin gameSkin;

	GameObject player;
	ScoreScript scoreScript;

	float gameScoreValue;
	int gameMultiValue;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		scoreScript = player.GetComponent<ScoreScript>();
	}

	void OnGUI() {
		GUI.skin = gameSkin;
		gameScoreValue = (int)scoreScript.GetScore();
		gameMultiValue = scoreScript.multiplier;
		string scoreText = "" + gameScoreValue;
		string multiText = "" + gameMultiValue;

		//Instantiate score object.
		GUI.Label(new Rect(200, 15, 100, 50), scoreText);
		GUI.Label(new Rect(10, 10, gameScore.width / 4, gameScore.height / 4), gameScore);

		//Instantiate the Multiplier value.
		GUI.Label (new Rect(600, 17, 100, 100), multiText);

		//Instantiate combo object.
		GUI.Label(new Rect(400, 15, gameCombo.width / 5, gameCombo.height / 5), gameCombo);

		//Instantiate the multiplier object.
		GUI.Label (new Rect(550, 15, gameMulti.width / 5, gameMulti.height / 5), gameMulti);
	}
}
