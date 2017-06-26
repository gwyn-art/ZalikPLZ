using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNote : MonoBehaviour {

	public TextMesh note;

	//there will be 2 methods of changing note: load from json(into distedu) and load from input field(into credit book)
	public void change() {
	}

	public void updateMark(string mark) {
		note.text = mark;
	}

	// Use this for initialization
	void Start () {
		change ();
	}
}
