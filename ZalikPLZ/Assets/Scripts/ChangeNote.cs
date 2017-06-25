using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeNote : MonoBehaviour {

	public TextMesh note;

	//there will be 2 methods of changing note: load from json(into distedu) and load from input field(into credit book)
		void change() {
			note.text = "100";
		}
		
	// Use this for initialization
	void Start () {
		change ();
	}
}
