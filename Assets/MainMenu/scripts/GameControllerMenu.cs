using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerMenu : MonoBehaviour
{
	public GameObject ShuttleFrame;
	public GameObject ShuttleFrameSelected;
	public GameObject ShuttleGameBoneRight;
	public GameObject ShuttleGameBoneRightSelected;
	public GameObject ShuttleGameBoneLeft;
	public GameObject ShuttleGameBoneLeftSelected;

	public GameObject BirdFrame;
	public GameObject BirdFrameSelected;
	public GameObject BirdGameBoneRight;
	public GameObject BirdGameBoneRightSelected;
	public GameObject BirdGameBoneLeft;
	public GameObject BirdGameBoneLeftSelected;

	public GameObject CarFrame;
	public GameObject CarFrameSelected;
	public GameObject CarGameBoneRight;
	public GameObject CarGameBoneRightSelected;
	public GameObject CarGameBoneLeft;
	public GameObject CarGameBoneLeftSelected;


	public GameObject MolesFrame;
	public GameObject MolesFrameSelected;
	public GameObject MolesGameBoneRight;
	public GameObject MolesGameBoneRightSelected;
	public GameObject MolesGameBoneLeft;
	public GameObject MolesGameBoneLeftSelected;


	public string CurrentState;

	string OldState;

	void Start ()
	{
		CurrentState = "Main";
		ChangeState ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (OldState != CurrentState)
			ChangeState ();
	}


	void ChangeState()
	{
		if (CurrentState == "Main") 
		{
			ShuttleFrame.SetActive (true);
			ShuttleFrameSelected.SetActive (false);
			ShuttleGameBoneRight.SetActive (true);
			ShuttleGameBoneRightSelected.SetActive (false);
			ShuttleGameBoneLeft.SetActive (true);
			ShuttleGameBoneLeftSelected.SetActive (false);

			BirdFrame.SetActive (true);
			BirdFrameSelected.SetActive (false);
			BirdGameBoneRight.SetActive (true);
			BirdGameBoneRightSelected.SetActive (false);
			BirdGameBoneLeft.SetActive (true);
			BirdGameBoneLeftSelected.SetActive (false);

			CarFrame.SetActive (true);
			CarFrameSelected.SetActive (false);
			CarGameBoneRight.SetActive (true);
			CarGameBoneRightSelected.SetActive (false);
			CarGameBoneLeft.SetActive (true);
			CarGameBoneLeftSelected.SetActive (false);

			MolesFrame.SetActive (true);
			MolesFrameSelected.SetActive (false);
			MolesGameBoneRight.SetActive (true);
			MolesGameBoneRightSelected.SetActive (false);
			MolesGameBoneLeft.SetActive (true);
			MolesGameBoneLeftSelected.SetActive (false);
		}


		else if (CurrentState == "ShuttleGame") 
		{
			ShuttleFrame.SetActive (false);
			ShuttleFrameSelected.SetActive (true);
			ShuttleGameBoneRight.SetActive (false);
			ShuttleGameBoneRightSelected.SetActive (true);
			ShuttleGameBoneLeft.SetActive (false);
			ShuttleGameBoneLeftSelected.SetActive (true);

			BirdFrame.SetActive (true);
			BirdFrameSelected.SetActive (false);
			BirdGameBoneRight.SetActive (true);
			BirdGameBoneRightSelected.SetActive (false);
			BirdGameBoneLeft.SetActive (true);
			BirdGameBoneLeftSelected.SetActive (false);

			CarFrame.SetActive (true);
			CarFrameSelected.SetActive (false);
			CarGameBoneRight.SetActive (true);
			CarGameBoneRightSelected.SetActive (false);
			CarGameBoneLeft.SetActive (true);
			CarGameBoneLeftSelected.SetActive (false);

			MolesFrame.SetActive (true);
			MolesFrameSelected.SetActive (false);
			MolesGameBoneRight.SetActive (true);
			MolesGameBoneRightSelected.SetActive (false);
			MolesGameBoneLeft.SetActive (true);
			MolesGameBoneLeftSelected.SetActive (false);
		}


		else if (CurrentState == "BirdGame") 
		{
			ShuttleFrame.SetActive (true);
			ShuttleFrameSelected.SetActive (false);
			ShuttleGameBoneRight.SetActive (true);
			ShuttleGameBoneRightSelected.SetActive (false);
			ShuttleGameBoneLeft.SetActive (true);
			ShuttleGameBoneLeftSelected.SetActive (false);

			BirdFrame.SetActive (false);
			BirdFrameSelected.SetActive (true);
			BirdGameBoneRight.SetActive (false);
			BirdGameBoneRightSelected.SetActive (true);
			BirdGameBoneLeft.SetActive (false);
			BirdGameBoneLeftSelected.SetActive (true);

			CarFrame.SetActive (true);
			CarFrameSelected.SetActive (false);
			CarGameBoneRight.SetActive (true);
			CarGameBoneRightSelected.SetActive (false);
			CarGameBoneLeft.SetActive (true);
			CarGameBoneLeftSelected.SetActive (false);

			MolesFrame.SetActive (true);
			MolesFrameSelected.SetActive (false);
			MolesGameBoneRight.SetActive (true);
			MolesGameBoneRightSelected.SetActive (false);
			MolesGameBoneLeft.SetActive (true);
			MolesGameBoneLeftSelected.SetActive (false);
		}

		else if (CurrentState == "CarGame") 
		{
			ShuttleFrame.SetActive (true);
			ShuttleFrameSelected.SetActive (false);
			ShuttleGameBoneRight.SetActive (true);
			ShuttleGameBoneRightSelected.SetActive (false);
			ShuttleGameBoneLeft.SetActive (true);
			ShuttleGameBoneLeftSelected.SetActive (false);

			BirdFrame.SetActive (true);
			BirdFrameSelected.SetActive (false);
			BirdGameBoneRight.SetActive (true);
			BirdGameBoneRightSelected.SetActive (false);
			BirdGameBoneLeft.SetActive (true);
			BirdGameBoneLeftSelected.SetActive (false);

			CarFrame.SetActive (false);
			CarFrameSelected.SetActive (true);
			CarGameBoneRight.SetActive (false);
			CarGameBoneRightSelected.SetActive (true);
			CarGameBoneLeft.SetActive (false);
			CarGameBoneLeftSelected.SetActive (true);

			MolesFrame.SetActive (true);
			MolesFrameSelected.SetActive (false);
			MolesGameBoneRight.SetActive (true);
			MolesGameBoneRightSelected.SetActive (false);
			MolesGameBoneLeft.SetActive (true);
			MolesGameBoneLeftSelected.SetActive (false);
		}

		else if (CurrentState == "MolesGame") 
		{
			ShuttleFrame.SetActive (true);
			ShuttleFrameSelected.SetActive (false);
			ShuttleGameBoneRight.SetActive (true);
			ShuttleGameBoneRightSelected.SetActive (false);
			ShuttleGameBoneLeft.SetActive (true);
			ShuttleGameBoneLeftSelected.SetActive (false);

			BirdFrame.SetActive (true);
			BirdFrameSelected.SetActive (false);
			BirdGameBoneRight.SetActive (true);
			BirdGameBoneRightSelected.SetActive (false);
			BirdGameBoneLeft.SetActive (true);
			BirdGameBoneLeftSelected.SetActive (false);

			CarFrame.SetActive (true);
			CarFrameSelected.SetActive (false);
			CarGameBoneRight.SetActive (true);
			CarGameBoneRightSelected.SetActive (false);
			CarGameBoneLeft.SetActive (true);
			CarGameBoneLeftSelected.SetActive (false);

			MolesFrame.SetActive (false);
			MolesFrameSelected.SetActive (true);
			MolesGameBoneRight.SetActive (false);
			MolesGameBoneRightSelected.SetActive (true);
			MolesGameBoneLeft.SetActive (false);
			MolesGameBoneLeftSelected.SetActive (true);
		}

		OldState = CurrentState;

	}



}








