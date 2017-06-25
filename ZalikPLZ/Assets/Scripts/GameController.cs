using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour {

	private static Students.Student currentStudent;
	private static Students.Student oldStudent;
	private static bool dataIsLoaded = false;
	private static bool isMoveToDesk = false;
	private static bool isMoveFromDesk = false;
	private static bool isStartTalking = false;
	private static bool isEndTalking = false;
	private readonly float timeTOWait = 1;
	private float timeIsWaiting = 1;

	void Start () {

	}

	void FixedUpdate () {
		if(!dataIsLoaded && StudentsController.DataIsLoaded) {
			currentStudent = StudentsController.getNextStudent();
			initStudent();
			dataIsLoaded = true;
		}

		if(isMoveToDesk) {
			GameObject onGoingStudent = currentStudent.StudentObject;
			onGoingStudent.transform.position =
				onGoingStudent.transform.position + new Vector3(currentStudent.speed * Time.deltaTime, 0, 0);
				if(onGoingStudent.transform.position.x > currentStudent.pointOnDesk) {
					isMoveToDesk = false;
					isStartTalking = true;
				}
		}

		if(isMoveFromDesk) {
			GameObject onGoingStudent = oldStudent.StudentObject;
			onGoingStudent.transform.position =
				onGoingStudent.transform.position + new Vector3(currentStudent.speed * Time.deltaTime, 0, 0);
				Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
				if(screenPosition.x < onGoingStudent.transform.position.x) {
					isMoveFromDesk = false;
					Destroy(onGoingStudent);
				}
		}

		if(timeIsWaiting > 0) {
			timeIsWaiting -= 1 * Time.deltaTime;
			return;
		}
		else {
			timeIsWaiting = timeTOWait;
		}

		if(isStartTalking) {
			string messege = currentStudent.say(true, false);
			if(messege != null) {
				print(messege);
			}
			else {
				isStartTalking = false;
			}
		}

		if(isEndTalking) {
			string messege = currentStudent.say(false, currentStudent.isSatisfyted(GetInputNote.Grade));
			ChangeRating.current.change(GetInputNote.Grade, currentStudent);

			if(messege != null) {
				print(messege);
			}
			else {
				isEndTalking = false;
				isMoveFromDesk = true;
				oldStudent = currentStudent;
				currentStudent = StudentsController.getNextStudent();
				if (currentStudent != null)
					initStudent();
				else
					gameEnd();
			}
		}
	}

	static void gameEnd () {
		print("The End.");
	}

	public static void endTalcking () {
		isEndTalking = true;
	}

	public static void initStudent () {
		GameObject student = Instantiate(StudentsController.StudentPrefab);
		Vector3 studentInitPosition = student.transform.position;
		studentInitPosition.x = -10;
		studentInitPosition.y = -3;
		studentInitPosition.z = 9;
		student.transform.position = studentInitPosition;
		currentStudent.StudentObject = student;
		print(currentStudent.sprite);
		Texture2D studentSprite = Resources.Load<Texture2D>("StudentsSprites/" + currentStudent.sprite);
		currentStudent.StudentObject.GetComponent<SpriteRenderer>().sprite =
			Sprite.Create(studentSprite, new Rect(0, 0, studentSprite.width, studentSprite.height),
										new Vector2(0.5f, 0.5f));
		moveToDesk(currentStudent);
	}

	public static void moveToDesk (Students.Student student) {
		isMoveToDesk = true;
	}

}
