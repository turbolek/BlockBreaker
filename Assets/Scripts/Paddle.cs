using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoplay = false;
	
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoplay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
		Vector3 paddlePosInBlocks = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePosInBlocks.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePosInBlocks;
	}
	
	void AutoPlay() {
			Vector3 paddlePosInBlocks = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
			Vector3 ballPos = ball.transform.position;
			paddlePosInBlocks.x = Mathf.Clamp(ballPos.x, 0.5f, 15.5f);
			this.transform.position = paddlePosInBlocks;
	}
}
