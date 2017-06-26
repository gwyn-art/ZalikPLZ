using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StudentsController : MonoBehaviour {

	public GameObject studentPrefab;

	public static GameObject StudentPrefab;
	private static string studentdsFileName = "students.json";
	private static Students loadedStudents;
	private static int currentSudent = 0;
	private static bool dataIsLoaded = false;

	bool isGameEnd = false;

	public static bool DataIsLoaded {
			get {
				return dataIsLoaded;
			}
	}

	public void Awake () {
		loadData();
		StudentPrefab = studentPrefab;
	}

	public static Students.Student getNextStudent () {
			return loadedStudents.studentsList[currentSudent++];
	}

	private static void loadData () {
		 string filePath = Path.Combine(Application.streamingAssetsPath, studentdsFileName);

		 if(File.Exists(filePath))
      {
        string studentdsAsJson = File.ReadAllText(filePath);
        loadedStudents = JsonUtility.FromJson<Students>(studentdsAsJson);
				dataIsLoaded = true;
      }
      else
      {
        Debug.LogError("Cannot load students data.");
      }
	}

}
