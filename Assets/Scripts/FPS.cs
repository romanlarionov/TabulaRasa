using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	int frameCount = 0;
	double dt = 0.0;
	double fps = 0.0;
	double updateRate = 4.0;  // 4 updates per sec.
	
	void Update()
	{
		frameCount++;
		dt += Time.deltaTime;
		if (dt > 1.0/updateRate)
		{
			fps = frameCount / dt ;
			frameCount = 0;
			dt -= 1.0/updateRate;
		}
		Debug.Log (fps);
	}
}
