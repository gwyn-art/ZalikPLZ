using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBtnStudent : MonoBehaviour {

	void OnMouseDown () {
		Tablet.current.hide();
		TabletStudent.current.show();
	}

}
