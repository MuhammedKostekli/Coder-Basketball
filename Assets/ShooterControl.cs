using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControl : MonoBehaviour {
	public Rigidbody ballPrefab;
	public float speed = 20.0F;
	private float startTime=0.0F;
	private float finishTime;


	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {

			startTime = Time.time;

		}
		//if (Time.time - startTime > 4.0F && Input.GetButton("Fire1")) {

		transform.position = transform.position + transform.forward * 0.5F;
		//}

		if (Input.GetButtonUp("Fire1") && Time.time - startTime <= 4.0F ) {
			finishTime = Time.time - startTime;
			var obj = (Rigidbody)Instantiate (ballPrefab, transform.position, transform.rotation);
			obj.velocity = (transform.forward + transform.up / 2) * speed * finishTime * 2;

		}

	}
}