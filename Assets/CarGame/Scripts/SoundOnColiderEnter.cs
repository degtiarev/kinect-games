using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AudioSource))]
public class SoundOnColiderEnter : MonoBehaviour
{

	public AudioClip noise;

	public GameObject Boom;

	// Update is called once per frame
	void OnTriggerEnter (Collider theCollision)
	{
		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.tag == "Player")
		{
			
		//AudioSource.PlayClipAtPoint (noise, transform.position);
			AudioSource.PlayClipAtPoint (noise, new Vector3(-1.500001f,214.45f,53.9f));

			if (this.tag != "Bonus") {

				Quaternion rotation = Quaternion.identity;
				rotation.eulerAngles = new Vector3 (0, 290, 0);

				Vector3 pos = new Vector3 ();
				pos.x = GameObject.FindGameObjectWithTag ("Player").transform.position.x;
				pos.y = GameObject.FindGameObjectWithTag ("Player").transform.position.y;
				pos.z = GameObject.FindGameObjectWithTag ("Player").transform.position.z;
				pos.x -= 5.57f;
				//	pos.y -= 3.36f;

				Instantiate (Boom, pos, rotation);

			}
		}
	
	}
}
