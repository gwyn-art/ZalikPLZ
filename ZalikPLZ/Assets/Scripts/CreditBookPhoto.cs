using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditBookPhoto : MonoBehaviour {

	public static CreditBookPhoto current;

	void Awake () {
		current = this;
	}

	public void updateBG(Sprite sprite) {
		GetComponent<SpriteRenderer>().sprite = sprite;
	}

}
