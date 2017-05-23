using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mole  
{
	public GameObject gameobject;
	public bool isUp;
	public float timer;
	public float animationDelay=1.1f;

	public Mole (GameObject gameobject)
	{
		this.gameobject = gameobject;
		isUp = false;
		timer = 0;
	}
}


public class VisualGestureMoles : MonoBehaviour, VisualGestureListenerInterface
{
	// GUI Texts to display the gesture messages.
	public GUIText discreteInfo;
	public GUIText continuousInfo;
	private bool discreteGestureDisplayed;
	private bool continuousGestureDisplayed;
	
	private float discreteGestureTime;
	private float continuousGestureTime;


	//new-------------------------------------
	public int MaxMolesAmount =3;
	private List<float> levelTimer=new List<float>(){2.0f, 1.8f, 1.6f, 1.5f, 1.3f, 1.2f, 1.0f, 0.8f, 0.7f, 0.5f};
	public int currentLevel=1;
	public int score=0;
	public  UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text levelText;

	Mole Mole1;
	Mole Mole2;
	Mole Mole3;
	Mole Mole4;
	Mole Mole5;

	float timer;

	//new-------------------------------------
	
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


		#region gestureEngine
		if (gesture == "first_Right")
		{
			if (Mole1.isUp==true)
				Bang(Mole1);
				else
				MissBang(Mole1);		
		}

		if (gesture == "second_Right")
		{
			if (Mole2.isUp==true)
				Bang(Mole2);
			else
				MissBang(Mole2);		
		}

		if (gesture == "third_Right" ||gesture.Contains("75"))
		{
			if (Mole3.isUp==true)
				Bang(Mole3);
			else
				MissBang(Mole3);		
		}

		
		if (gesture == "fourth_Right")
		{
			if (Mole4.isUp==true)
				Bang(Mole4);
			else
				MissBang(Mole4);		
		}

		
		if (gesture == "fifth_Right")
		{
			if (Mole5.isUp==true)
				Bang(Mole5);
			else
				MissBang(Mole5);		
		}

		#endregion

		// reset the gesture
		return true;
	}
		
	public void Update()
	{
		#region standart
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
		#endregion

		#region UpEngine
		timer -= Time.deltaTime;
		if (timer <=0) 
		{
			timer =levelTimer[currentLevel-1];
			int nextMole= Random.Range(1,6);


			if (nextMole==1 && Mole1.isUp==false&& Mole1.animationDelay==1.1f)
			{
				moveUp(Mole1);
			}

			else if (nextMole==2 && Mole2.isUp==false && Mole2.animationDelay==1.1f)
			{
				moveUp(Mole2);
			}

			else if (nextMole==3 && Mole3.isUp==false&& Mole3.animationDelay==1.1f)
			{
				moveUp(Mole3);
			}

			else if (nextMole==4 && Mole4.isUp==false&& Mole4.animationDelay==1.1f)
			{
				moveUp(Mole4);
			}

			else if (nextMole==5 && Mole5.isUp==false&& Mole5.animationDelay==1.1f)
			{
				moveUp(Mole5);
			}

		}
		#endregion

		#region DownEngine
		moleTimerSubtrack(Mole1);
		moleTimerSubtrack(Mole2);
		moleTimerSubtrack(Mole3);
		moleTimerSubtrack(Mole4);
		moleTimerSubtrack(Mole5);

		#endregion

		#region scoreEngine
		
		if (score>=10 && currentLevel==10)
			Time.timeScale=0;
		else if (score>=10) 
		{
			score=0;
			currentLevel++;
		}
		scoreText.text="Счет: "+score;
		levelText.text="Уровень: "+currentLevel;
	
		#endregion
	}

	public void Start ()
	{
		GameObject level = GameObject.Find ("LevelStorage");
		MolesLevelStorage startlevel = level.GetComponent<MolesLevelStorage> ();
		
		if (startlevel!=null)
			currentLevel = startlevel.StartLevel;



		timer = 3;
		Mole1 = new Mole (GameObject.Find("Mole1"));
		Mole2 = new Mole (GameObject.Find("Mole2"));
		Mole3 = new Mole (GameObject.Find("Mole3"));
		Mole4 = new Mole (GameObject.Find("Mole4"));
		Mole5 = new Mole (GameObject.Find("Mole5"));
	
	}

	void moveUp(Mole mole)
	{
		Animation anim = mole.gameobject.GetComponent<Animation> ();
		anim.Play("Up");
		mole.isUp=true;
		mole.timer = levelTimer [currentLevel - 1];
	}

	void moleTimerSubtrack (Mole mole)
	{
		if (mole.isUp == true && mole.timer>=0)
			mole.timer -= Time.deltaTime;

		if (mole.timer <= 0 && mole.isUp==true&& mole.animationDelay==1.1f) 
		{
			Animation anim = mole.gameobject.GetComponent<Animation> ();
			anim.Play("Down");
			mole.timer = 0;
			mole.animationDelay-=Time.deltaTime;
		}

		if (mole.animationDelay<1.1f)
			mole.animationDelay-=Time.deltaTime;

		if (mole.animationDelay<=0)
		{
			mole.animationDelay=1.1f;
			mole.isUp=false;	
		}
	}

	void Bang(Mole mole)
	{
		Animation anim = mole.gameobject.GetComponent<Animation> ();
		anim.Play("Bang");
		mole.animationDelay = 1.1f;
		mole.isUp = false;
		mole.timer = 0;
		score++;
	}

	void MissBang (Mole mole)
	{
		Animation anim = mole.gameobject.GetComponent<Animation> ();
		anim.Play("MissBang");

	}
}
