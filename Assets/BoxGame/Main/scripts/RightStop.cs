using UnityEngine;
using System.Collections;

public class RightStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "box") {
			collider.gameObject.GetComponent<Rigidbody> ().isKinematic = false;

			GameObject mechanism = GameObject.Find ("magnetColider");
			ParentingTheBox parentingTheBox = (ParentingTheBox)mechanism.GetComponent (typeof(ParentingTheBox));

			parentingTheBox.isConnected = false;


			GameObject truck = GameObject.Find ("Truck");


			collider.gameObject.transform.parent = truck.transform;

			if (collider.gameObject.name.Contains ("blue") && collider.gameObject.GetComponent<BoxesMove>().isCounted==false) {
				

				collider.gameObject.GetComponent<BoxesMove> ().isCounted = true;
				GameObject gcontroller = GameObject.Find ("GameController");
				GameController script = gcontroller.GetComponent<GameController> ();
				script.score++;
			}



			//Debug.Log ("Вошел в зону сброса");

		}
	}


}
