using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBtnGrades : MonoBehaviour {

	void OnMouseDown () {
		TabletStudent.current.hide();
		Tablet.current.show();
	}
	
}
