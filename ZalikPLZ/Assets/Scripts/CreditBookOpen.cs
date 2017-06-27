using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBookOpen : MonoBehaviour {

	public static CreditBookOpen current;

	void Start () {
		current = this;
		this.hide();
	}

	void OnMouseDown () {
		AudioController.current.clickTune();
		this.hide();
	  CreditBookInteraction.current.show();
	}

	public void show() {
		this.gameObject.SetActive(true);
	}

	public void hide() {
		this.gameObject.SetActive(false);
	}

	public void updateMarks (int[] marks) {
		TextMesh[] fields = this.GetComponentsInChildren<TextMesh>();

		for(int i = 0; i < fields.Length; i++) {
			if(fields[i].gameObject.tag == "Mark")
				fields[i].text = marks[i].ToString();
		}
	}
}
