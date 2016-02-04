using UnityEngine;
using System.Collections;

public class CollectableScript : MonoBehaviour {

	void OnEnable() { //when the game object is activated
		Invoke ("DestroyCollectable", 6f);
	}

	void DestroyCollectable() {
		gameObject.SetActive(false);
	}
}
