using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GetInputNote : MonoBehaviour {
	private static int grade;

	public static int Grade {
		get {
			return grade;
		}
	}

	void Start (){
		var input = gameObject.GetComponent<InputField>();
		var se= new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		input.onEndEdit = se;
	}

	private void SubmitName(string arg0){
		grade = int.TryParse(arg0);
	}
}
