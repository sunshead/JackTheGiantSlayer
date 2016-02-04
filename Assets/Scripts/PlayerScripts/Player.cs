using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 8f;
	public float maxVelocity = 4f;

	private Rigidbody2D myBody;
	private Animator anim;

	void Awake () {
		myBody = GetComponent<Rigidbody2D> (); // get the component from the game object
		anim = GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame, FixedUpdate is called every fixed framerate frame
	// Best place to put functions that deal with physics
	void FixedUpdate () {
		PlayerMoveKeyboard ();
	}

	void PlayerMoveKeyboard() {
		float forceX = 0f;
		float vel = Mathf.Abs (myBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal"); //A -1 S 0 D 1
		if (h > 0) { //we are pushing "D", in the right direction
			if (vel < maxVelocity)
				forceX = speed; //we can still move

			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);

		} else if (h < 0) {
			if (vel < maxVelocity)
				forceX = -speed; //going to the left side

			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);

		} else {
			anim.SetBool ("Walk", false);
		}
		myBody.AddForce (new Vector2 (forceX, 0));
	}
}
