using UnityEngine;
using System.Collections;

public class LeftConveyor : MonoBehaviour {

	void OnTriggerEnter (Collider collider)
	{


		BoxesMove boxesMove = collider.gameObject.GetComponent<BoxesMove>();
		// Get current health
		boxesMove.isOnLeftConveyer=true;

		if (collider.gameObject.name.Contains ("red")&&  collider.gameObject.GetComponent<BoxesMove>().isCounted==false) {

			collider.gameObject.GetComponent<BoxesMove> ().isCounted = true;
			GameObject gcontroller= GameObject.Find("GameController");
			GameController script = gcontroller.GetComponent<GameController> ();
			script.score++;
		}
	}




}
