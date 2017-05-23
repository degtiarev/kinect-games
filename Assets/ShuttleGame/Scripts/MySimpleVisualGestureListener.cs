using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MySimpleVisualGestureListener : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;
	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;
	private float discreteGestureTime;
	private float continuousGestureTime;

	//new-------------------------------------
	public List <int> gestures;
	private List<string> tempGestures;
	private bool firstPart;
	private bool secondPart;
	private bool thirdPart;
	private bool fourthPart;
	private bool fifthPart;// удалить потом
	private Animation anim;
	private bool isFinish;

	float timer=1.0f;
	float curentTimerValue;
	float finishTimer=6.0f;
	bool isLastDone;


	//new-------------------------------------

	public void GestureInProgress (long userId, int userIndex, string gesture, float progress)
	{
		if (continuousInfo != null) {
			string sGestureText = string.Format ("{0} {1:F0}%", gesture, progress * 100f);
			continuousInfo.GetComponent<GUIText> ().text = sGestureText;

			continuousGestureDisplayed = true;
			continuousGestureTime = Time.realtimeSinceStartup;
		}
	}

	public bool GestureCompleted (long userId, int userIndex, string gesture, float confidence)
	{
		if (discreteInfo != null) {
			string sGestureText = string.Format ("{0}-gesture detected, confidence: {1:F0}%", gesture, confidence * 100f);
			//new-------------------------------------
			if (!firstPart)
			{
				if (gesture.Contains("Right_Leg") && curentTimerValue==0.0f)
				{
					tempGestures.Add(gesture);
					curentTimerValue=timer;
				}
				else 
				{
					if (curentTimerValue>0)
					{
						tempGestures.Add(gesture);
					}

					if (curentTimerValue<0)
					{
						List<int> temp= new List<int>();
						firstPart=true;
						Debug.Log("1");

						foreach (var i in tempGestures)
						{
							if (i=="RightLeg100") temp.Add(100);
							else if (i=="Right_Leg_60") temp.Add(60);
							else temp.Add(30);

						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
						anim.Play("Right_Leg01");
					}
				}

			}

			if (firstPart&&!secondPart)
			{
				if (gesture.Contains("Right_Leg") && curentTimerValue==0.0f)
				{
					tempGestures.Add(gesture);
					curentTimerValue=timer;
				}
				else 
				{
					if (curentTimerValue>0)
					{
						tempGestures.Add(gesture);
					}

					if (curentTimerValue<0)
					{
						List<int> temp= new List<int>();
						secondPart=true;
						Debug.Log("2");

						foreach (var i in tempGestures)
						{
							if (i=="RightLeg100") temp.Add(100);
							else if (i=="Right_Leg_60") temp.Add(60);
							else temp.Add(30);
						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
						anim.Play("Left_Leg01");
					}

				}
			}


			if (secondPart&&!thirdPart)
			{
				if (gesture.Contains("Left_Leg")&&curentTimerValue==0.0f)
				{
					tempGestures.Add(gesture);
					curentTimerValue=timer;
				}
				else 
				{
					if (curentTimerValue>0)
					{
						tempGestures.Add(gesture);
					}

					if (curentTimerValue<0)
					{

						List<int> temp= new List<int>();
						thirdPart=true;
						Debug.Log("3");

						foreach (var i in tempGestures)
						{
							if (i=="LeftLeg100") temp.Add(100);
							else if (i=="Left_Leg_60") temp.Add(60);
							else temp.Add(30);

						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
						anim.Play("Left_Leg02");
					}

				}
			}


			if (thirdPart&&!fourthPart)
			{
				if (gesture.Contains("Left_Leg")&&curentTimerValue==0.0f)
				{
					tempGestures.Add(gesture);
					curentTimerValue=timer;
				}
				else 
				{
					if (curentTimerValue>0)
					{
						tempGestures.Add(gesture);
					}

					if (curentTimerValue<0)
					{
						List<int> temp= new List<int>();
						fourthPart=true;
						Debug.Log("4");

						foreach (var i in tempGestures)
						{
							if (i=="LeftLeg100") temp.Add(100);
							else if (i=="Left_Leg_60") temp.Add(60);
							else temp.Add(30);

						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
						anim.Play("Left_Leg03");
					}

				}
			}

			/*if (fourthPart&&!fifthPart)
			{
				if (curentTimerValue==0.0f)
				{
					tempGestures.Add(gesture);
					curentTimerValue=timer;
				}
				else 
				{
					if (curentTimerValue>0)
					{
						tempGestures.Add(gesture);
					}

					if (curentTimerValue<0)
					{

						List<int> temp= new List<int>();
						fifthPart=true;
						Debug.Log("5");

						foreach (var i in tempGestures)
						{
							if (i=="TwoArms100" ||i=="TwoArmsX100" ) temp.Add(100);
							else if (i=="TwoArms60" || i=="TwoArmsX60") temp.Add(60);
							else temp.Add(30);

						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
					}

				}
			}*/

			//new-------------------------------------
			discreteInfo.GetComponent<GUIText> ().text = sGestureText;

			discreteGestureDisplayed = true;
			discreteGestureTime = Time.realtimeSinceStartup;
		}

		// reset the gesture
		return true;
	}

	public void Update ()
	{
		// clear gesture infos after a while
		if (continuousGestureDisplayed && ((Time.realtimeSinceStartup - continuousGestureTime) > 1f)) {
			continuousGestureDisplayed = false;

			if (continuousInfo != null) {
				continuousInfo.GetComponent<GUIText> ().text = string.Empty;
			}
		}

		if (discreteGestureDisplayed && ((Time.realtimeSinceStartup - discreteGestureTime) > 1f)) {
			discreteGestureDisplayed = false;

			if (discreteInfo != null) {
				discreteInfo.GetComponent<GUIText> ().text = string.Empty;
			}
		}



		////
		if (firstPart && secondPart && thirdPart && fourthPart &&! isFinish)
		{
			finishTimer-=Time.deltaTime;

			if (finishTimer<3 && !isLastDone)
			{
				//anim.Play("Left_Leg02");
				isLastDone=true;
			}
			if (finishTimer<0)
				isFinish=true;
		}



		if (curentTimerValue > 0)
			curentTimerValue -= Time.deltaTime;
		else
			GestureCompleted (0,0,"0",0.0f);



		if (isFinish) 
		{
			
			GameObject score = GameObject.Find ("Level");
			ShuttleGameLevelStorage levelStorage= score.GetComponent<ShuttleGameLevelStorage>();


			if (gestures[3]==30) levelStorage.StartLevel=1;
			else if (gestures[3]==60) levelStorage.StartLevel=3;
			else levelStorage.StartLevel=4;

			Application.LoadLevel("проект 3");

		}

	}/// <summary>

	public void Start ()
	{
		//new-------------------------------------
		gestures = new List<int> ();
		tempGestures = new List<string> ();
		GameObject Avatar = GameObject.Find ("hands001");
		anim = Avatar.GetComponent<Animation> ();
		anim.Play("RightLeg");
		//new-------------------------------------
	}

	public void OnGUI () {
		if (GUI.Button (new Rect (25, 700, 200, 30), "Выход")) {
			Application.Quit ();
		}
	}

}
