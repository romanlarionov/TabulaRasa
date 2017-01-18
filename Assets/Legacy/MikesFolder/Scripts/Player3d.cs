using UnityEngine;
using System.Collections;

public class Player3d : MonoBehaviour 
{
	public float forwardSpeed = 3;
	public float turnSpeed    = 2;

	private float initialForwardSpeed;
	
	// Use this for initialization
	void Start () 
	{
		initialForwardSpeed = forwardSpeed;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float forwardMoveAmount = Input.GetAxis  ("Vertical")  * forwardSpeed;	//actual forward speed
		float turnAmount 		= Input.GetAxis ("Horizontal") * turnSpeed;		//actual turn speed

		transform.Rotate (0, turnAmount, 0);				//rotate the vehicle

		rigidbody.AddRelativeForce (0, 0, -forwardMoveAmount);	//push the vehicle forward with a force	

		if (Input.GetKeyDown("space")) 
		{
			forwardSpeed *= 5;
			print (forwardSpeed);
		}

		if(Input.GetKeyUp("space"))
		{
			forwardSpeed = initialForwardSpeed;
			print (forwardSpeed);
		}
	
	}
}
