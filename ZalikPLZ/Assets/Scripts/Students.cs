using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Students {
	public Student[] studentsList;

	[System.Serializable]
	public class Student {
		public float speed = 2f;
		public float pointOnDesk = 5f;
		private GameObject studentObject;
		private bool speachCondition;
		private int textCount;

		public GameObject StudentObject {
			set {
				this.studentObject = value;
			}
			get {
				return studentObject;
			}
		}

		//name
		public string name;
		//what student say on start
		public string[] startSpeach;
		//what student say on good end
		public string[] endGoodSpeach;
		//what student say on bad end
		public string[] endBadSpeach;
		// home works marks
		public int[] homeWorks;
		//plagiats
		public int[] plagiats;
		//marks from another subjects
		public int[] anotherSubjects;
		//mark student want to get
		public int markWanted;
		//min mark with which student will not be angry
		public int markMin;
		//mark student deserve
		public int markDeserve;
		//work sprite
		public string spriteWork;
		//background
		public string sprite;

		public bool isSatisfyted (int grade) {
			return grade > markMin ? true : false;
		}

		public string say (bool start, bool goodEnd) {
			if(start) {
				if(textCount < startSpeach.Length) {
					return startSpeach[textCount++];
				}
				else {
					textCount = 0;
					return null;
				}
			}
			if(!start && goodEnd) {
				if(textCount < endGoodSpeach.Length) {
					return endGoodSpeach[textCount++];
				}
				else {
					textCount = 0;
					return null;
				}
			}
			else {
				if(textCount < endBadSpeach.Length) {
					return endBadSpeach[textCount++];
				}
				else {
					textCount = 0;
					return null;
				}
			}
		}

	}
}
