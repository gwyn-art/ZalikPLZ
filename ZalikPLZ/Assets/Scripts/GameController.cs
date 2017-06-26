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

	int studentsCounter = 0;

	public GameObject level1;
	public GameObject level2;
	public GameObject level3;
	public GameObject level4;
	public GameObject level5;
	public GameObject level6;
	public GameObject level7;



	void Start () {
		level1.SetActive (false);
		level2.SetActive (false);
		level3.SetActive (false);
		level4.SetActive (false);
		level5.SetActive (false);
		level6.SetActive (false);
		level7.SetActive (false);

	}

	void FixedUpdate () {
		if(!dataIsLoaded && StudentsController.DataIsLoaded) {
			currentStudent = StudentsController.getNextStudent();
			initStudent();
			dataIsLoaded = true;
			studentsCounter += 1;
			Debug.Log (studentsCounter);
			StartCoroutine (loadLevel());
		}

		if(isMoveToDesk) {
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
				onGoingStudent.transform.position + new Vector3(currentStudent.speed * Time.deltaTime, 0, 0);
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
			ChangeRating.current.change(GetInputNote.Grade, currentStudent);
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
		this.levelName ().SetActive (true);
		yield return new WaitForSeconds (2f);
		this.levelName ().SetActive (false);

	}

	public GameObject levelName(){
		if(studentsCounter == 1)
			return level1;
		else if(studentsCounter == 2)
			return level2;
		else if(studentsCounter == 3)
			return level3;
		else if(studentsCounter == 4)
			return level4;
		else if(studentsCounter == 5)
			return level5;
		else if(studentsCounter == 6)
			return level6;
		else 
			return level7;

	}

}
