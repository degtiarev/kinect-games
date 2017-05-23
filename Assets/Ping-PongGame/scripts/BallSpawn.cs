using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;


public class BallSpawn : MonoBehaviour {

	public Transform ball;
	public  UnityEngine.UI.Text showToCatch;

	public  UnityEngine.UI.Text scoreText;
	public  UnityEngine.UI.Text levelText;

	float timeLeft = 2.0f;

	public int level;
	public int score;

	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {

		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			showToCatch.text="Внимание! Мяч летит!";
			Instantiate(ball, transform.position, Quaternion.identity);
			timeLeft = 5.0f;
		}

		if (score >= 10) {

			level++;
			score = 0;
		}

		scoreText.text = "Счет: " + score;
		levelText.text = "Уровень: " + level;
			
	}
}
