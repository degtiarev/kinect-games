using UnityEngine;
using System.Collections;

public class boxDetector : MonoBehaviour {

	void OnTriggerEnter (Collider collider)
	{

		GameObject spawner = GameObject.Find ("Spawns");
		Spawner spawnerScript = spawner.GetComponent<Spawner>();
		spawnerScript.boxesSpawn();

	}
}
