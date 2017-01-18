
using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public Texture gameBackground;
	public Texture startTitle;
	public Texture playButton;

	void Update() {
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), gameBackground);
		GUI.Label(new Rect (0, 10, startTitle.width,  startTitle.height), startTitle);

		if (GUI.Button(new Rect(250, 300, playButton.width, playButton.height), playButton))
			Application.LoadLevel("MasterGameScene");
	}
}
