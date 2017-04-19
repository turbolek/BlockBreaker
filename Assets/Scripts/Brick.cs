using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCounter = 0;
	
	public AudioClip crack;
	public LevelManager levelManager;
	public Sprite[] hitSprites;
	public GameObject smoke;
	
	
	private int hitCounter;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCounter++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		hitCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}

	}
	
	void LoadSprites(){
		int spriteIndex = hitCounter - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Sprite not found");
		}
	}
	
	void HandleHits() {
		hitCounter++;
		int maxHits = hitSprites.Length + 1;
		if (hitCounter >= maxHits){
			Destroy(gameObject);
			EmitSmoke();
			breakableCounter--;
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}
	
	void EmitSmoke() {
		GameObject smokeCopy = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		smokeCopy.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
}
