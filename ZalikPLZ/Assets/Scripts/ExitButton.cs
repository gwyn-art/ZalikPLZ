using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ExitButton : MonoBehaviour {
	
	public UnityEvent signalOnClick = new UnityEvent();

	public void _onClick() {
		this.signalOnClick.Invoke ();
	}

	void Start(){
		signalOnClick.AddListener(this.onPlay);
	}

	void onPlay() { 
		Debug.Log ("Quit the game");
		Application.Quit();
	}
}
