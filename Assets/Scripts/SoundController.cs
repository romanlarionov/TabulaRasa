using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {


	public AudioClip [] notes;
	private float 	 clipTimer;
	public int 	 clipCount;
	// Use this for initialization
	void Start () 
	{
		clipTimer = 0.0f;
		clipCount = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		clipTimer -= Time.deltaTime;
		if(clipTimer < 0.0f)
		{
			clipTimer = 0.0f;
			clipCount = clipCount - Random.Range(0,clipCount);
		}

	}
	public void StartSound()
	{
		clipTimer += 2.0f;

		if(clipCount != 8)
			clipCount++;
		else
			clipCount = clipCount - Random.Range(0,clipCount);

		PlayClip();
	}
	public void PlayClip()
	{
		this.audio.PlayOneShot(notes[clipCount]);
	}
}
