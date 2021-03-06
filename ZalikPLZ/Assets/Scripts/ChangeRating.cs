﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeRating : MonoBehaviour {

	Text rtext;
	public int currentRating = 100;
	public readonly int studentWeight = 2;
	public readonly int deserveWeight = 3;
	public static ChangeRating current;

	void Awake () {
		current = this;
		rtext = GetComponent<Text>();
		changeRating(100);
	}

	void changeRating (int newRating) {
		currentRating = newRating;
		rtext.text = "" + newRating;
	}

	public void change(int grade, Students.Student student) {
		int newRating = 0;
		if(student.markWanted - student.markDeserve < 20) {
	 		newRating = currentRating + (grade - student.markWanted + grade - student.markMin) * studentWeight +
									(Math.Abs(grade - student.markDeserve) * -1 + 5) * deserveWeight;
		}
		else {
			newRating = currentRating + (Math.Abs(grade - student.markDeserve) * -1 + 5) * deserveWeight;
		}


		if(newRating >= currentRating) {
			AudioController.current.rightGradeTune();
		}
		else {
			AudioController.current.wrongGradeTune();
		}

		if(newRating > 100)
			newRating = 100;
		else if(newRating < 0)
			newRating = 0;
		changeRating(newRating);
	}
}
