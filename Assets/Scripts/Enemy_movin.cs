using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movin : MonoBehaviour {

	public float maxSpeed;
	public Transform player;
	public GameObject enemy;
	public Transform papa;
	private Rigidbody2D rigi;


	void Update () {
		var rigi = GetComponent<Rigidbody2D> ();
		float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3 (player.transform.position.x, player.transform.position.y, z);
		rigi.AddForce (gameObject.transform.up * maxSpeed);

		if (Time.time >= 20f) {
			maxSpeed = maxSpeed + 0.05f;
		}

		}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (gameObject);
		}
	}



}
