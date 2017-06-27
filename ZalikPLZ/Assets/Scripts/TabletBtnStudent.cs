using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBtnStudent : MonoBehaviour {

	void OnMouseDown () {
		AudioController.current.clickTune();
		Tablet.current.hide();
		TabletHint.current.hide();
		TabletStudent.current.show();
	}

}
