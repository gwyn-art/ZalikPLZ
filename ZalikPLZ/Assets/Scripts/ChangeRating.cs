using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRating : MonoBehaviour {
	
	public Text rtext;

	void Start () {
		rtext = GetComponent<Text>();
		changeRating (100);
	}

	void changeRating(int newRating){
		rtext.text = "Your rating: " + newRating;
	
	}
}
