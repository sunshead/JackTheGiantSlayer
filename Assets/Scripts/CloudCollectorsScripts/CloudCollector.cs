using UnityEngine;
using System.Collections;

public class CloudCollector : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D target) { //called when other collider touches collector, here target is the other collider
		if (target.tag == "Cloud" || target.tag == "Deadly") {
			target.gameObject.SetActive (false); //deactivate the object in	the scene
		}
	}
}
