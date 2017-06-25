using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public static Test current;

	void Start () {
			current = this;
	}

	public void updateBG(Sprite sprite) {
		GetComponent<SpriteRenderer>().sprite = sprite;
	}
}
