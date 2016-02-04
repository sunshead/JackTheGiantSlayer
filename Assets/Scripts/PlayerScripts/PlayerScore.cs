using UnityEngine;
using System.Collections;

public class PlayerScore : MonoBehaviour {

	[SerializeField]
	private AudioClip coinClip, lifeClip;

	private CameraScripts cameraScript;

	private Vector3 previousPosition;
	private bool countScore;

	public static int scoreCount;
	public static int lifeCount;
	public static int coinCount;

	void Awake() {
		cameraScript = Camera.main.GetComponent<CameraScripts> ();
	}

	void Start () {
		previousPosition = transform.position;
		countScore = true;
	}
	
	// Update is called once per frame
	void Update () {
		CountScore ();
	}

	void CountScore() {
		if (countScore) {
			if (transform.position.y < previousPosition.y) {
				scoreCount++;
			}
			previousPosition = transform.position;
		}
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.tag == "Coin") {
			coinCount++;
			scoreCount += 200;

			AudioSource.PlayClipAtPoint (coinClip, transform.position);
			target.gameObject.SetActive (false);
		}

		if (target.tag == "Life") {
			lifeCount++;
			scoreCount += 300;

			AudioSource.PlayClipAtPoint (lifeClip, transform.position);
			target.gameObject.SetActive (false);
		}

		if (target.tag == "Bounds") { //if player dies, we are not going to move camera
			cameraScript.moveCamera = false;
			countScore = false;

			transform.position = new Vector3 (500, 500, 0); //put player outside the camera to simulate his death.
			lifeCount--;
		}

		if (target.tag == "Deadly") {
			cameraScript.moveCamera = false;
			countScore = false;

			transform.position = new Vector3 (500, 500, 0); //put player outside the camera to simulate his death.
			lifeCount--;
		}
	}
}
