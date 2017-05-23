using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SimpleVisualGestureGirlBox : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;
	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;
	private float discreteGestureTime;
	private float continuousGestureTime;

	//new-------------------------------------
	private List <int> gestures;
	private List<string> tempGestures;
	private bool firstPart;
	private bool secondPart;

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
				if (gesture.Contains("Right") && curentTimerValue==0.0f)
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
							if (i=="Arm100_Right") temp.Add(100);
							else temp.Add(50);

						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
						anim.Play("Left");
					}
				}

			}

			if (firstPart&&!secondPart)
			{
				if (gesture.Contains("Left") && curentTimerValue==0.0f)
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
							if (i=="Arm100_Left") temp.Add(100);
							else if (i=="Arm60_Left") temp.Add(60);
							else temp.Add(30);
						}
						temp.Sort();
						tempGestures=new List<string>();
						gestures.Add(temp[temp.Count-1]);
						curentTimerValue=0.0f;
					}

				}
			}




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




		if (firstPart && secondPart && ! isFinish)
		{
			finishTimer-=Time.deltaTime;

			if (finishTimer<3 && !isLastDone)
			{
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
			BoxGameLevelStorage levelStorage= score.GetComponent<BoxGameLevelStorage>();


			if (gestures[0]==50 || gestures[1]==50) levelStorage.StartLevel=1;
			else levelStorage.StartLevel=4;

			Application.LoadLevel("MainBox");

		}

	}

	public void Start ()
	{
		//new-------------------------------------
		gestures = new List<int> ();
		tempGestures = new List<string> ();
		GameObject Avatar = GameObject.Find ("hands001");
		anim = Avatar.GetComponent<Animation> ();
		anim.Play("Right");
		//new-------------------------------------
	}

}
