using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBtnGrades : MonoBehaviour {

	void OnMouseDown () {
		AudioController.current.clickTune();
		TabletStudent.current.hide();
		TabletHint.current.hide();
		Tablet.current.show();
	}

}
