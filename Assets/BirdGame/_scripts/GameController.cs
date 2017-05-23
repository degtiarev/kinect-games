using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class GameController : MonoBehaviour 
{
	public int limitScore;
	public GameObject finish;
	public int score;
	public  UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text currentLevelText;
	public int currentLevel;
	
	public List<float> levelParameters;

	// Use this for initialization
	void Start () 
	{
		GameObject level = GameObject.Find ("Level");
		LevelStorage startlevel = level.GetComponent<LevelStorage> ();

		if (startlevel!=null)
		currentLevel = startlevel.StartLevel;
		UpdateScore ();
		UpdateLevel ();

	}
	
	// Update is called once per frame
	void Update () 
	{

		float newBirdPositionY;
		float ArmYPosition;

		GameObject MainCamera = GameObject.Find ("Main Camera");
		GetJointPositionDemo jointPosition = MainCamera.GetComponent<GetJointPositionDemo>();

		//if (jointPosition != null)
			ArmYPosition = jointPosition.outputPosition.y;
		//else
		//	ArmYPosition = GameObject.Find ("bird").transform.position.y;
	
		if (ArmYPosition != 0.0f) {
			newBirdPositionY = 18.6f + (2.0f * (((ArmYPosition - 0.7f) / (levelParameters [currentLevel - 1] / 100)) / 100));
			//Debug.Log (levelParameters [currentLevel - 1]);

			if (newBirdPositionY > 20.6f)
				newBirdPositionY = 20.6f;
			if (newBirdPositionY < 18.6f)
				newBirdPositionY = 18.6f;

			GameObject.Find ("bird").transform.position = new Vector3 (11.0f, newBirdPositionY, 0.47f);
		}

	}

	void UpdateScore()
	{
		scoreText.text = "Счет: " + score;
	}

	void UpdateLevel()
	{
		currentLevelText.text = "Уровень: " + currentLevel;

	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

		if (score >= limitScore ) 
		{
			currentLevel++;
			score=0;
			UpdateLevel();
			UpdateScore();

			if  (score >= limitScore && currentLevel>=levelParameters.Count) 
			StartCoroutine(WaitSomeSeconds());

		}
		
	}

	IEnumerator WaitSomeSeconds()
	{
		Instantiate (finish, new Vector3(12.1f,21.2f,7f), new Quaternion(0.0f, 0.0f, 0.0f,0.0f));
		yield return new WaitForSeconds(1.0f);  //Wait 1 seconds
		Time.timeScale = 0.0f;
		GetComponent<AudioSource> ().Stop ();
	}


}
