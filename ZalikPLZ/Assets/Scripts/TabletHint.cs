using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletHint : MonoBehaviour {

	public static TabletHint current;

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
}
