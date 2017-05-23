using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameSettings : MonoBehaviour {

	public double limitScore;
	public double score=0;
	public static double AllScore=0;
	public  UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text currentLevelText;
	//public UnityEngine.UI.Text AllScoreText;
//	public Text scoreFinalText;
	public static int currentLevel;
	public GameObject a;
	public PlaneRotate planerotate;

	// Use this for initialization
	void Start () {
		
		GameObject level = GameObject.Find ("Level");
		ShuttleGameLevelStorage startlevel = level.GetComponent<ShuttleGameLevelStorage> ();

		if (startlevel != null)
			currentLevel = Convert.ToInt32(startlevel.StartLevel);
		else 
		{
			currentLevel = 1;
		}
		UpdateScore ();
		UpdateLevel ();

		planerotate = a.GetComponent<PlaneRotate>();

	}

	void Update () {
		UpdateScore ();

		//UpdateAllScore ();
	}


	void UpdateScore()
	{
		scoreText.text = "Очки: " + score;
	}

	void UpdateLevel()
	{
		currentLevelText.text = "Уровень: " + currentLevel;
	}



	//void UpdateAllScore()
	//{
	//	AllScoreText.text = "Все очки: " + AllScore;
	//}

	public void AddScore(double newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		AllScore += newScoreValue;
		//UpdateAllScore ();

		if (score >= limitScore ) 
		{
			currentLevel++;
			score=0;
			UpdateLevel();
			UpdateScore();
			PlaneRotate.speedRotation += 5;
			if (currentLevel > 5) {
				Time.timeScale = 0;
				Application.LoadLevel ("Canvas");
			}
				
		}


		}

	public void OnGUI () {
		if (GUI.Button (new Rect (25, 700, 100, 30), "Стоп")) {
			Application.LoadLevel ("Canvas");
		}
	}
	}



	
	//void SetCountText()
	//{
		//scoreFinalText.text = "Всего очков: " + AllScore;
	



