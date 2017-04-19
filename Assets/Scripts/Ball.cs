using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
	paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			if (Input.GetMouseButtonDown(0)) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 6f);
				hasStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
		if (hasStarted) {
			GetComponent<AudioSource>().Play ();		
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
	
}
