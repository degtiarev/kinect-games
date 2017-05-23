using UnityEngine;
using System.Collections;

public class PlaneVisualGesture : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;

	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;

	private float discreteGestureTime;
	private float continuousGestureTime;

	public GameObject plane;
	private PlaneController planeScript;

	void Start ()
	{
		planeScript = plane.GetComponent<PlaneController>();

	}

	public void GestureInProgress(long userId, int userIndex, string gesture, float progress)
	{
		if(continuousInfo != null)
		{
			string sGestureText = string.Format ("{0} {1:F0}%", gesture, progress * 100f);
			continuousInfo.GetComponent<GUIText>().text = sGestureText;

			continuousGestureDisplayed = true;
			continuousGestureTime = Time.realtimeSinceStartup;
		}
	}

	public bool GestureCompleted(long userId, int userIndex, string gesture, float confidence)
	{
		if(discreteInfo != null)
		{
			string sGestureText = string.Format ("{0}-gesture detected, confidence: {1:F0}%", gesture, confidence * 100f);
			discreteInfo.GetComponent<GUIText>().text = sGestureText;

			discreteGestureDisplayed = true;
			discreteGestureTime = Time.realtimeSinceStartup;
		}

		if (gesture == "Right_Leg_60")
			planeScript.turnLeft ();
		if (gesture == "Left_Leg_60")
			planeScript.turnRight();



		// reset the gesture
		return true;
	}

	public void Update()
	{
		// clear gesture infos after a while
		if(continuousGestureDisplayed && ((Time.realtimeSinceStartup - continuousGestureTime) > 1f))
		{
			continuousGestureDisplayed = false;

			if(continuousInfo != null)
			{
				continuousInfo.GetComponent<GUIText>().text = string.Empty;
			}
		}

		if(discreteGestureDisplayed && ((Time.realtimeSinceStartup - discreteGestureTime) > 1f))
		{
			discreteGestureDisplayed = false;

			if(discreteInfo != null)
			{
				discreteInfo.GetComponent<GUIText>().text = string.Empty;
			}
		}
	}

}