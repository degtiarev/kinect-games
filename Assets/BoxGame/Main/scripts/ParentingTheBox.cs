using UnityEngine;
using System.Collections;

public class ParentingTheBox : MonoBehaviour
{
	public bool isConnected = false;

	GameObject cube = null;

	void Update ()
	{
		if (isConnected) {
			cube.transform.position = transform.position + new Vector3 (0, -0.25f, 0);// new Vector3 (0, -0.6f, 0);
		}

	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.tag == "box") {
			BoxesMove other = (BoxesMove)collider.gameObject.GetComponent (typeof(BoxesMove));

			if (other.wasPicked == false) {
				cube = collider.gameObject;
				other.isStopped = true;
				other.wasPicked = true;

				if (!isConnected)
					cube.GetComponent<Rigidbody> ().isKinematic = true;
			
				isConnected = true;
				Debug.Log ("Объект захвачен");
			}

		}

	}


}