using UnityEngine;
using System.Collections;

public class LeftStop : MonoBehaviour {

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

			Debug.Log ("Вошел в зону сброса");
		}
	}


}
