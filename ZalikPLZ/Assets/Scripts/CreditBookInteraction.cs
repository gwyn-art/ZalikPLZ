using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBookInteraction : MonoBehaviour {

	public static CreditBookInteraction current;

	void Start () {
		current = this;
	}

 	void OnMouseDown () {
		this.hide();
	  CreditBookOpen.current.show();
	}

	public void show() {
		this.gameObject.SetActive(true);
	}

	public void hide() {
		this.gameObject.SetActive(false);
	}
}
