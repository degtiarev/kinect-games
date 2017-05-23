using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour {


	public int score;
	public  UnityEngine.UI.Text scoreText;
	// Use this for initialization
	void Start () {
		UpdateScore ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateScore()
	{
		scoreText.text = "Очки: " + score;
	}

	public void AddScore(int newScoreValue)
	{
		score=0;
		score += newScoreValue;
		UpdateScore ();

		}

	}


