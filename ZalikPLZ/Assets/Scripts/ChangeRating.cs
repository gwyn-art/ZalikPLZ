using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeRating : MonoBehaviour {

	Text rtext;
	int currentRating = 100;
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
		rtext.text = "Your rating: " + newRating;
	}

	public void change(int grade, Students.Student student) {
		int newRating = currentRating + (grade - student.markWanted + grade - student.markMin) * studentWeight +
									(Math.Abs(grade - student.markDeserve) * -1 + 3) * deserveWeight;
		if(newRating > 100)
			newRating = 100;
		else if(newRating < 0)
			newRating = 0;
		changeRating(newRating);
	}
}
