using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour {

	public static GameController current;
	public static Students.Student currentStudent;
	private static Students.Student oldStudent;
	private static bool dataIsLoaded = false;
	private static bool isMoveToDesk = false;
	private static bool isMoveFromDesk = false;
	private static bool isStartTalking = false;
	private static bool isEndTalking = false;
	private readonly float timeTOWait = 2;
	private float timeIsWaiting = 2;

	int studentsCounter = 0;

	public UILabel levelLabel;
	public GameObject level;
	public GameObject gGame;
	public GameObject bGame;

	AudioController ac;

	void Start () {
		current = this;
		ac = GetComponent<AudioController> ();
		//ac.mainTune ();
		level.SetActive (false);
		gGame.SetActive (false);
		bGame.SetActive (false);
	}

	void FixedUpdate () {
		if(!dataIsLoaded && StudentsController.DataIsLoaded) {
			currentStudent = StudentsController.getNextStudent();
			initStudent();
			dataIsLoaded = true;
			studentsCounter += 1;
			Debug.Log (studentsCounter);
			StartCoroutine (loadLevel());
			AudioController.current.stepsTune();
		}

		if(isMoveToDesk && currentStudent != null) {
			GameObject onGoingStudent = currentStudent.StudentObject;
			onGoingStudent.transform.position =
				onGoingStudent.transform.position + new Vector3(currentStudent.speed * Time.deltaTime, 0, 0);
				if(onGoingStudent.transform.position.x > currentStudent.pointOnDesk) {
					isMoveToDesk = false;
					StudentText.current.clear();
					isStartTalking = true;
				}
		}

		if(isMoveFromDesk) {
			GameObject onGoingStudent = oldStudent.StudentObject;
			onGoingStudent.transform.position =
				onGoingStudent.transform.position + new Vector3(oldStudent.speed * Time.deltaTime, 0, 0);
				Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
				if(screenPosition.x < onGoingStudent.transform.position.x) {
					isMoveFromDesk = false;
					StudentText.current.clear();
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
				StudentText.current.addLine(messege);
			}
			else {
				isStartTalking = false;
			}
		}

		if(isEndTalking) {
			string messege = currentStudent.say(false, currentStudent.isSatisfyted(GetInputNote.Grade));
			if(messege != null) {
				StudentText.current.addLine(messege);

			}
			else {
				isEndTalking = false;
				isMoveFromDesk = true;
				oldStudent = currentStudent;
				currentStudent = StudentsController.getNextStudent();

				if (currentStudent != null) {
					initStudent ();
					AudioController.current.stepsTune();
					//LOAD LEVEL NAME SCENE
					studentsCounter += 1;
					Debug.Log (studentsCounter);
					StartCoroutine (loadLevel());

				}
				else
					gameEnd();
			}


		}
	}

	public void gameEnd() {
		if(ChangeRating.current.currentRating >= 60) {
			goodGameEnd();
		}
		else {
			badGameEnd();
		}
	}

	public void goodGameEnd () {
		AudioController.current.startAndVictoryTune();
		this.gGame.SetActive (true);

	}

	public void badGameEnd () {
		AudioController.current.badEndTune();
		this.bGame.SetActive (true);

	}

	public static void endTalcking () {
		isEndTalking = true;
	}

	public static void initStudent () {
		GameObject student = Instantiate(StudentsController.StudentPrefab);
		Vector3 studentInitPosition = student.transform.position;
		studentInitPosition.x = -10;
		studentInitPosition.y = -1.9f;
		studentInitPosition.z = 9;
		student.transform.position = studentInitPosition;
		currentStudent.StudentObject = student;

		Tablet.current.updateMarks(currentStudent.homeWorks);
		Tablet.current.updatePlagiats(currentStudent.plagiats);
		CreditBookOpen.current.updateMarks(currentStudent.anotherSubjects);
		TabletStudent.current.updateAttendance(currentStudent.attendance);

		Texture2D studentSprite = Resources.Load<Texture2D>("StudentsSprites/" + currentStudent.sprite);
		currentStudent.StudentObject.GetComponent<SpriteRenderer>().sprite =
			Sprite.Create(studentSprite, new Rect(0, 0, studentSprite.width, studentSprite.height),
										new Vector2(0.5f, 0.5f));

		Texture2D creditBookPhoto = Resources.Load<Texture2D>("StudentsSprites/" + currentStudent.creditBookPhoto);
		print(CreditBookPhoto.current);
		CreditBookPhoto.current.updateBG(Sprite.Create(creditBookPhoto,
										new Rect(0, 0, creditBookPhoto.width, creditBookPhoto.height),
										new Vector2(0.5f, 0.5f)));

		Texture2D studentWorkSprite = Resources.Load<Texture2D>("StudentsWorks/" + currentStudent.spriteWork);
		Test.current.updateBG(Sprite.Create(studentWorkSprite,
										new Rect(0, 0, studentWorkSprite.width, studentWorkSprite.height),
										new Vector2(0.5f, 0.5f), 180f));

		moveToDesk(currentStudent);
	}

	public static void moveToDesk (Students.Student student) {
		isMoveToDesk = true;
	}


	IEnumerator loadLevel(){
		this.level.SetActive (true);
		this.levelLabel.text = "Level " + studentsCounter;
		yield return new WaitForSeconds (2f);
		this.level.SetActive (false);

	}

}
