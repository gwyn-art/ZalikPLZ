using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public UnityEvent signalOnClick = new UnityEvent();
	public GameObject levelBackground;

	public void _onClick() {
		this.signalOnClick.Invoke ();
	}

	void Start(){
		levelBackground.SetActive (false);
		signalOnClick.AddListener(this.onPlay);
	}

	void onPlay() { 
		//StartCoroutine (loadLevel());
		SceneManager.LoadScene("Classroom");
	}

	IEnumerator loadLevel(){

		levelBackground.SetActive (true);

		yield return new WaitForSeconds (1.2f);
		SceneManager.LoadScene("Classroom");
	}

}
