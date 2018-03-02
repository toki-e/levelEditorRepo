using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public KeyCode upKey = KeyCode.W;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode downKey = KeyCode.S;
	public KeyCode leftKey = KeyCode.A;
	public float moveSpeed = 10f;


	Rigidbody2D _body;


	// Use this for initialization
	void Start () {
		_body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

		Vector2 newVelocity = new Vector2(0, 0);
		if (Input.GetKey(upKey)) {
			newVelocity.y += moveSpeed;
		}
		if (Input.GetKey(rightKey)) {
			newVelocity.x += moveSpeed;
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		if (Input.GetKey(downKey)) {
			newVelocity.y -= moveSpeed;
		}
		if (Input.GetKey(leftKey)) {
			newVelocity.x -= moveSpeed;
			GetComponent<SpriteRenderer> ().flipX = false;
		}

		newVelocity = newVelocity.normalized*moveSpeed;

		_body.velocity = newVelocity;
	}
}
