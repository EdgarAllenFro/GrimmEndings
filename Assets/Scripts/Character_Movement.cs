using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour {
	public float maxSpeed = 10f;
	private Rigidbody2D rigi;

	float leftConstraint = Screen.width;
	float rightConstraint = Screen.width;
	float bottomConstraint = Screen.height;
	float topConstraint = Screen.height;
	float buffer = 1.0f;
	Camera cam;
	float distanceZ;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

		leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
		rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
		bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
		topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
	}

	private void Awake()
	{
		rigi = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//player movement on both axes
		float moveLR = Input.GetAxis ("Horizontal");
		float moveUD = Input.GetAxis ("Vertical");
		rigi.velocity = new Vector2(moveLR * maxSpeed, rigi.velocity.y);
		rigi.velocity = new Vector2(rigi.velocity.x, moveUD * maxSpeed);


		if (transform.position.x < leftConstraint - buffer) {
			transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
		}
		if (transform.position.x > rightConstraint + buffer) {
			transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
		}
		if (transform.position.y < bottomConstraint - buffer) {
			transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
		}
		if (transform.position.y > topConstraint + buffer) {
			transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
		}
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy") {
			Destroy (gameObject);
		}

	}
}

