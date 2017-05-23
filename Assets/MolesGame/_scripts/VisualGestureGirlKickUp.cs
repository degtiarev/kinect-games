using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisualGestureGirlKickUp : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;
	
	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;
	
	private float discreteGestureTime;
	private float continuousGestureTime;

	public bool isDone;
	Animation anim;
	public float animTimer=5.0f;
	List<string> gestures;
	
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

		if (gesture.Contains ("25") || gesture.Contains ("50") || gesture.Contains ("75") || gesture.Contains ("100"))
		if (isDone == false)
		{
			isDone = true;
			animTimer = 5.0f;
			gestures.Add (gesture);
		}
		else 
		{
			gestures.Add(gesture);
		}




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


		if (isDone==false && animTimer>=5.0f) 
		{
			anim.Play("kick");
			animTimer-=Time.deltaTime;
		}

		if (animTimer <= 0&& isDone==false)
			animTimer = 6.0f;

		animTimer -= Time.deltaTime;


		if (animTimer <= 0 && isDone == true) 
		{
			int ChosenLevel=1;
			gestures.Sort();
			if (gestures[gestures.Count-1].Contains("25") ) ChosenLevel=1;
			else if (gestures[gestures.Count-1].Contains("50") ) ChosenLevel=2;
			else if (gestures[gestures.Count-1].Contains("75") ) ChosenLevel=3;
			else if (gestures[gestures.Count-1].Contains("100") ) ChosenLevel=4;

			GameObject level = GameObject.Find ("LevelStorage");
			MolesLevelStorage levelStorage= level.GetComponent<MolesLevelStorage>();
			
			
		 levelStorage.StartLevel=ChosenLevel;

			
			Application.LoadLevel("MainMoles");

		}

	}

	public void Start()
	{
		GameObject Avatar = GameObject.Find ("topKick");
		anim = Avatar.GetComponent<Animation> ();

		gestures = new List<string> ();
	}
	
}
