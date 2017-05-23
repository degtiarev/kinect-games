using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {


	public List <GameObject> boxes;  //для коробок
	public List <Transform> places; //для мест с которых появляются коробки

	public float boxSpeed;


	void Start () {
		boxesSpawn ();
	}
		
		

	public void boxesSpawn()
	{
		int spawnBoxInd = Random.Range (0, boxes.Count);
		int spawnPlacesInd = Random.Range (0, places.Count);

		GameObject box = boxes [spawnBoxInd];
		BoxesMove boxmove = box.GetComponent<BoxesMove> ();
		boxmove.speed = boxSpeed;

		Instantiate (box, places [spawnPlacesInd].position, Quaternion.identity);
	}


}

