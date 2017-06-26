using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentText : MonoBehaviour {

	public static StudentText current;
	TextMesh text;

	void Start () {
			current = this;
			text = GetComponent<TextMesh>();
	}

	public void clear () {
		text.text = "";
	}

	public void addLine (string line) {
		text.text += line + "\n";
	}
}
