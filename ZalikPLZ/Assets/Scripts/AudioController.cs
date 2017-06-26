using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	//	SOUNDS
	public AudioClip badEnd = null;
	public AudioClip clickOnItems = null;
	public AudioClip mainTheme = null;
	public AudioClip startAndVictory = null;
	public AudioClip steps = null;
	public AudioClip rightGrade = null;
	public AudioClip wrongGrade = null;

	AudioSource badEndSource = null;
	AudioSource clickSource = null;
	AudioSource mainSource = null;
	AudioSource startAndVictorySource = null;
	AudioSource stepsSource = null;
	AudioSource rightGradeSource = null;
	AudioSource wrongGradeSource = null;

	// Use this for initialization
	void Start () {
		badEndSource = gameObject.AddComponent<AudioSource> ();
		badEndSource.clip = badEnd;

		clickSource = gameObject.AddComponent<AudioSource> ();
		clickSource.clip = clickOnItems;

		stepsSource = gameObject.AddComponent<AudioSource> ();
		stepsSource.clip = steps;

		mainSource = gameObject.AddComponent<AudioSource> ();
		mainSource.clip = mainTheme;

		startAndVictorySource = gameObject.AddComponent<AudioSource> ();
		startAndVictorySource.clip = startAndVictory;

		rightGradeSource = gameObject.AddComponent<AudioSource> ();
		rightGradeSource.clip = rightGrade;

		wrongGradeSource = gameObject.AddComponent<AudioSource> ();
		wrongGradeSource.clip = wrongGrade;
	}

	public void badEndTune() {
		badEndSource.Play ();
	}

	public void mainTune() {
		mainSource.Play ();
	}

	public void stepsTune() {
		stepsSource.Play ();
	}

	public void startAndVictoryTune() {
		startAndVictorySource.Play ();
	}

	public void rightGradeTune() {
		rightGradeSource.Play ();
	}

	public void wrongGradeTune() {
		wrongGradeSource.Play ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
