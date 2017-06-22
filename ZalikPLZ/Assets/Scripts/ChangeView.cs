using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour {

	readonly float studentViewRotation = 1;
	readonly float deskViewRotation = 35;
	readonly float rotationSpeed = 7f;
	int rotationStatus = 0;

	void Update () {
		float cameraRotationX = transform.localRotation.eulerAngles.x;

		if (Input.GetKeyDown(KeyCode.Space) && rotationStatus == 0) {
				if(cameraRotationX >= deskViewRotation)
					rotationStatus = -1;
				else
					rotationStatus = 1;
		}

		if(rotationStatus == -1) {
			if(cameraRotationX > studentViewRotation) {
				transform.rotation = Quaternion.Euler(new Vector3(--cameraRotationX, transform.rotation.y, transform.rotation.z));
			}
			else {
				rotationStatus = 0;
			}
		}
		else if(rotationStatus == 1) {
			if(cameraRotationX < deskViewRotation) {
				transform.rotation = Quaternion.Euler(new Vector3(++cameraRotationX, transform.rotation.y, transform.rotation.z));
			}
			else {
				rotationStatus = 0;
			}
		}
	}

}
