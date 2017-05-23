using System;
using UnityEngine;

public class TimeScript : MonoBehaviour {
	private DateTime timeBegin;
	private TimeSpan a;
	private TimeSpan timeTimer;
	public static string timeString;
	public Rect rectTimer = new Rect(10, 10, 100, 20);

	void Start() {
		timeBegin = DateTime.Now; 
	}

	private void Update() {
		a = DateTime.Now - timeBegin  ;
		timeTimer = TimeSpan.Parse("00:00:00") + a;
		timeString = string.Format("{0:D2}:{1:D2}:{2:D2}", timeTimer.Hours, timeTimer.Minutes, timeTimer.Seconds);
	}

	void OnGUI() {
		GUI.Label(rectTimer, timeString);
	}
}