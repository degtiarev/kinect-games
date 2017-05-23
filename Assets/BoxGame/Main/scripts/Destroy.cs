using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{


	void OnTriggerEnter (Collider collider)
	{

		if (collider.gameObject.tag != "truck")
			Destroy (collider.gameObject);
		else {
			GameObject truck = GameObject.Find ("Truck");
			for (int i = 0; i < truck.transform.GetChildCount (); i++) {
				GameObject Go = truck.transform.GetChild (i).gameObject;
				if (Go.gameObject.tag.Equals ("box")) {
					Destroy (Go);
				}

			}


		}
	}
}
