﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletBtnHint : MonoBehaviour {

	void OnMouseDown () {
		Tablet.current.hide();
		TabletStudent.current.hide();
		TabletHint.current.show();
	}

}
