using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletStudent : MonoBehaviour {

	public static TabletStudent current;

	void Start () {
			current = this;
			hide();
	}

	public void show() {
		this.gameObject.SetActive(true);
	}

	public void hide() {
		this.gameObject.SetActive(false);
	}

	public void updateAttendance (string[] attendance) {
		TextMesh[] fields = this.GetComponentsInChildren<TextMesh>();

		for(int i = 0, j = 0; i < fields.Length; i++) {
			if(fields[i].gameObject.tag == "Attendance") {
				fields[i].text = attendance[j].ToString();
				j++;
			}
		}
	}
}
