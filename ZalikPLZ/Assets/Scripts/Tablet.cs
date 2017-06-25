using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {
	public static Tablet current;

	void Start () {
		current = this;
	}

	public void updateMarks (int[] marks) {
		TextMesh[] fields = this.GetComponentsInChildren<TextMesh>();

		for(int i = 0; i < fields.Length; i++) {
			if(fields[i].gameObject.tag == "Mark")
				fields[i].text = marks[i].ToString();
		}
	}
}
