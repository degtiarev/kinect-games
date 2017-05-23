using UnityEngine;
using System.Collections;
using System.Collections;
using UnityEngine.UI;
using System;


public class ChangeText : MonoBehaviour {

	public  UnityEngine.UI.Text showToCatch;

	float timeLeft = 1.0f;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		if (showToCatch.text!="")
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			timeLeft = 1.0f;
			showToCatch.text="";
		}
	
	}
}
