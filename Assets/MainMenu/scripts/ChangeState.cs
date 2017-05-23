using UnityEngine;
using System.Collections;

public class ChangeState : MonoBehaviour
{

	public string gameName;
	string scenename;

	GameControllerMenu controller;


	void Start ()
	{
		GameObject GameController = GameObject.Find ("GameControllerMenu");
		controller = GameController.GetComponent<GameControllerMenu> ();

		if (gameName == "MolesGame")
			scenename = "CalibrationMoles";

		if (gameName=="BirdGame")
			scenename="CalibrationBird";

		if (gameName=="CarGame")
			scenename="CalibrationCar";
		
		if (gameName == "ShuttleGame")
			scenename = "CalibrationShuttle";

	}


	void OnMouseEnter ()
	{
		controller.CurrentState = gameName;
	}

	void OnMouseExit ()
	{
		controller.CurrentState="Main";
	}

	void OnMouseDown() {
//		if (scenename!="CalibrationShuttle")
		Application.LoadLevel(scenename);
	}
}
