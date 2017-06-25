using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeRating : MonoBehaviour {

	Text rtext;
	public readonly int studentWeight = 2;
	public readonly int deserveWeight = 3;
	public static ChangeRating current;

	void Start () {
		current = this;
		rtext = GetComponent<Text>();
		changeRating(100);
	}

	void changeRating (int newRating) {
		rtext.text = "Your rating: " + newRating;
	}

	public void change(int grade, Students.Student student) {
		changeRating((grade - student.markWanted + grade - student.markMin) * studentWeight +
									(Math.Abs(grade - student.markDeserve) * -1 + 3 * deserveWeight));
	}
}
