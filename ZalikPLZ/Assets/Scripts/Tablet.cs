using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tablet : MonoBehaviour {
	public static Tablet current;
	public Color red;
	public Color black;
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

	public void updatePlagiats (int[] plagiats) {
		TextMesh[] fields = this.GetComponentsInChildren<TextMesh>();
		for(int i = 0, j = 0; i < fields.Length; i++) {
			if(fields[i].gameObject.tag == "Plagiat") {
				fields[i].text = plagiats[j].ToString() + "%";
				if(plagiats[j] > 20) {
					fields[i].color =  red;
				}
				else {
					fields[i].color = black;
				}
				j++;
			}
		}
	}

	public void show() {
		this.gameObject.SetActive(true);
	}

	public void hide() {
		this.gameObject.SetActive(false);
	}
}
