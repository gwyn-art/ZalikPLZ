using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : MonoBehaviour {

	readonly float studentViewRotation = 1;
	readonly float deskViewRotation = -10.5f;
	int rotationStatus = 0;

	void Update () {
		Vector3 cameraPosition = transform.position;
		float cameraPositionY = cameraPosition.y;

		if (Input.GetKeyDown(KeyCode.Space) && rotationStatus == 0) {
				if(cameraPositionY > deskViewRotation)
					rotationStatus = -1;
				else
					rotationStatus = 1;
		}

		if(rotationStatus == -1) {
			if(cameraPositionY > deskViewRotation) {
				cameraPosition.y = cameraPositionY - 0.5f;
				transform.position = cameraPosition;
			}
			else {
				rotationStatus = 0;
			}
		}
		else if(rotationStatus == 1) {
			if(cameraPositionY < studentViewRotation) {
				cameraPosition.y = cameraPositionY + 0.5f;
				transform.position = cameraPosition;
			}
			else {
				rotationStatus = 0;
			}
		}
	}

}
