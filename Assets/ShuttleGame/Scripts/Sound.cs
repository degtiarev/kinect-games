using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class Sound : MonoBehaviour
{

	public AudioClip noise1;
	//public GameObject Player;
	public int Score; 




	void OnTriggerEnter (Collider theCollision)
	{
		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.tag == "Plane")
			AudioSource.PlayClipAtPoint (noise1, transform.position);
		//Destroy (collisionGO);

		
	}
		


		} 






