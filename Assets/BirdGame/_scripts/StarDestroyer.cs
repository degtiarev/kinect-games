using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class StarDestroyer : MonoBehaviour
{

	public AudioClip noise1;
	public AudioClip noise2;
	private bool flag;


	// Update is called once per frame
	void OnTriggerEnter (Collider theCollision)
	{
		GameObject collisionGO = theCollision.gameObject;
		if (collisionGO.tag == "Player")
		{
			int choose= Random.Range(0,10);
			if (choose>5) flag=true;
			else flag=false;

			if (flag) 
			{
				AudioSource.PlayClipAtPoint (noise1, transform.position);
				flag = false;
			} 
			else
			{
				AudioSource.PlayClipAtPoint (noise2, transform.position);
				flag=true;
			}

		}
	}
}
