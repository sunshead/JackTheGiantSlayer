using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void StartGame() {
		Application.LoadLevel ("GamePlay");
	}

	public void HighscoreMenu() {
		Application.LoadLevel ("HighscoreScene");
	}

	public void OptionsMenu() {
		Application.LoadLevel ("OptionsMenu");
	}

	public void QuitGame() {
		Application.Quit ();
	}

	public void MusicButton() {
	}
}
