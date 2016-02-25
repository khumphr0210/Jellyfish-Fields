using UnityEngine;
using System.Collections;

public class swim : MonoBehaviour 
{

	public float speed = 120.0f;
	public float horSpeed = 80.0f;
	public Rigidbody2D rb2d;
	public bool airborn = false;
	//public float posY;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			if (!airborn) {
				rb2d.AddForce (transform.up * speed);
				//Debug.Log ("Jump");
			}
		}

		if (Input.GetAxis("Horizontal") > 0)
		{
			rb2d.AddForce (transform.right * (horSpeed/8));
		}

		if (Input.GetAxis("Horizontal") < 0)
		{
			rb2d.AddForce (transform.right * (-horSpeed/8));
		}

		//posY = rb2d.transform.position.y;
		if (airborn) { // && rb2d.transform.position.y > posY) {
			rb2d.drag += .01f;
		} 
		else 
		{
			rb2d.drag = 0;
		}
		//Debug.Log (rb2d.transform.position.y.ToString());
		//Debug.Log ("AIRBORN: " + airborn.ToString ());
	}

	void OnTriggerEnter2D ()
	{
		// lessen mass
		rb2d.mass = 2.5f;
		rb2d.drag = 0f;
		airborn = false;
	}

	void OnTriggerStay2D ()
	{
		//

	}

	void OnTriggerExit2D ()
	{
		airborn = true;
		// increase mass so player can't jump into the sky
		rb2d.mass = 6f;
	}
}
