using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisualGestureCarGirl : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;
	
	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;
	
	private float discreteGestureTime;
	private float continuousGestureTime;

	//---------------------------------------------------------------
	public int amoutDoneGestures = 0;
	Animation anim;
	public float animTimer = 5.0f;
	//---------------------------------------------------------------

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
			discreteInfo.GetComponent<GUIText> ().text = sGestureText;
			
			discreteGestureDisplayed = true;
			discreteGestureTime = Time.realtimeSinceStartup;
		}

		//---------------------------------------------------------------

		if (amoutDoneGestures == 0 && gesture == "LeftLeg")
			amoutDoneGestures++;

		if (amoutDoneGestures == 1 && gesture == "RightLeg")
			amoutDoneGestures++;

		if (amoutDoneGestures == 2 && gesture == "LeftLeg")
			amoutDoneGestures++;

		if (amoutDoneGestures == 3 && gesture == "RightLeg")
			amoutDoneGestures++;
		

		//---------------------------------------------------------------



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

		//---------------------------------------------------------------
		if (amoutDoneGestures != 4 && animTimer >= 5.0f) {
			if (amoutDoneGestures == 0)
				anim.Play ("45right");
			if (amoutDoneGestures == 1)
				anim.Play ("45left");
			if (amoutDoneGestures == 2)
				anim.Play ("90right");
			if (amoutDoneGestures == 3)
				anim.Play ("90left");
			animTimer -= Time.deltaTime;
		}

		if (animTimer <= 0 && amoutDoneGestures != 4)
			animTimer = 6.0f;

		animTimer -= Time.deltaTime;


		if (animTimer <= 0 && amoutDoneGestures == 4 ) {
			Application.LoadLevel ("MainCar");
		}

		//---------------------------------------------------------------

	}

	public void Start ()
	{
		GameObject Avatar = GameObject.Find ("topKick");
		anim = Avatar.GetComponent<Animation> ();

	}
	
}
