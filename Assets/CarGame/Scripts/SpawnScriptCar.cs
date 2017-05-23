using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class distance
{
	public float from;
	public float to;
}

public class SpawnScriptCar : MonoBehaviour
{
	public GameObject world;
	public GameObject blockage;
	public GameObject hill;
	public GameObject hole;
	public GameObject oilTank1;
	public GameObject oilTank2;
	public GameObject trafficLight;
	public GameObject turnLeft;
	public GameObject turnRight;


	private  Vector3 blockageCenter;
	private  Vector3 blockageLeft;
	private  Vector3 blockageRight;
	private  Vector3 hillCenter;
	private  Vector3 hillLeft;
	private  Vector3 hillRight;
	private  Vector3 holeCenter;
	private  Vector3 holeLeft;
	private  Vector3 holeRight;
	private  Vector3 oilTankCenter;
	private  Vector3 oilTankRight;
	private  Vector3 oilTankLeft;
	private Vector3 VturnLeft;
	private Vector3 VturnRight;
	private Vector3 VtrafficLight;

		
	public float nextSomething = 0.0f;
	public float spawnRate = 3f;

	private bool shouldBeSpawn = false;
	public int savePosition = 0;

	void Start ()
	{
		blockageLeft = new Vector3 (2.76f, blockage.transform.position.y, blockage.transform.position.z);
		blockageRight = new Vector3 (-4.93f, blockage.transform.position.y, blockage.transform.position.z);
		blockageCenter = new Vector3 (blockage.transform.position.x, blockage.transform.position.y, blockage.transform.position.z);

		hillLeft = new Vector3 (5.49f, hill.transform.position.y, hill.transform.position.z);
		hillRight = new Vector3 (-2.89f, hill.transform.position.y, hill.transform.position.z);
		hillCenter = new Vector3 (hill.transform.position.x, hill.transform.position.y, hill.transform.position.z);

		holeLeft = new Vector3 (-6f, hole.transform.position.y, hole.transform.position.z);
		holeRight = new Vector3 (-14f, hole.transform.position.y, hole.transform.position.z);
		holeCenter = new Vector3 (hole.transform.position.x, hole.transform.position.y, hole.transform.position.z);

		oilTankLeft = new Vector3 (3.88f, oilTank1.transform.transform.position.y, oilTank1.transform.position.z);
		oilTankRight = new Vector3 (-4.4f, oilTank1.transform.transform.position.y, oilTank1.transform.position.z);
		oilTankCenter = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

		VturnLeft = new Vector3 (turnLeft.transform.position.x, turnLeft.transform.position.y, turnLeft.transform.position.z);
		VturnRight = new Vector3 (turnRight.transform.position.x, turnRight.transform.position.y, turnRight.transform.position.z);
		VtrafficLight = new Vector3 (trafficLight.transform.position.x, trafficLight.transform.position.y, trafficLight.transform.position.z);

	
	}

	void Update ()
	{
		// 1) каждые n секунд ставится припятствие (имеется в виду все 3)
		if (nextSomething < Time.time) {
			nextSomething = Time.time + spawnRate;

			shouldBeSpawn = true;

			Spawn ();
		}
	}

	void Spawn ()
	{
		// 2) с вероятностью 33% выбирается, какая из трех позиций (слева, посередине, справа) безопасная
		// 3) ставим слева, справа или светофор - показатель, куда нужно повернуть
		if (shouldBeSpawn && savePosition==0) {
	
				savePosition = DecisionMakerByAmountofVarients (3);
		
				if (savePosition == 1)
					SpawnByPosition (turnLeft);
				else if (savePosition == 2)
					SpawnByPosition (trafficLight);
				else if (savePosition == 3)
					SpawnByPosition (turnRight);

				shouldBeSpawn = false;
		}


		// 4) на каждую ячейку, кроме безопасной ставится с вероятностью 50% перегородка, знак с ямой
		if (shouldBeSpawn)
		{
			for (int i = 1; i <= 3; i++)
			{
				if (i != savePosition) 
				{
					int choose = DecisionMakerByAmountofVarients (2);
					if (choose == 1)
						SpawnByPosition (blockage, i);
					else if (choose == 2)
						SpawnByPosition (hole, i);
				
				}
			}

			// 5) с вероятностью 50% на безопасную ячейку с вероятностью 33% ставится бонус1, бонус2 или горка

			//if (BinaryDecisionMakerByAmountofVarients (2)) 
			{
				int choose = DecisionMakerByAmountofVarients (3);

				//Debug.Log (choose);

				if (choose == 1)
					SpawnByPosition (oilTank1, savePosition);
				else if (choose == 2)
					SpawnByPosition (oilTank2, savePosition);
				else if (choose == 3)
					SpawnByPosition (hill, savePosition);
			}

			savePosition = 0;

		}
			
		//SpawnConcreteObject (hill, hillCenter);


	}



	void SpawnConcreteObject (GameObject gameObject, Vector3 spawnPosition)
	{
		Quaternion prefQuart = new Quaternion (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
		GameObject prefab = Instantiate (gameObject, spawnPosition, prefQuart) as GameObject;
		prefab.transform.parent = world.transform;
	}

	bool BinaryDecisionMakerByAmountofVarients (int amountOfVarients)
	{
		float everyPart = 100f / (float)amountOfVarients;
		float randomNumber = (float)Random.Range (1, 100);	
		if (everyPart >= randomNumber)
			return true;
		else
			return false;
	}

	int DecisionMakerByAmountofVarients (int amountOfVarients)
	{
		int result = 0;
		float everyPart = 100f / (float)amountOfVarients;
		float randomNumber = (float)Random.Range (1, 100);	

		List<distance> groups = new List<distance> ();

		float tempSumm = 0;
		for (int i = 0; i < amountOfVarients; i++) {
			distance myDistance = new distance ();
			myDistance.from = tempSumm;
			tempSumm += everyPart;
			myDistance.to = tempSumm;
			if (i == amountOfVarients - 1)
				myDistance.to = 100;
			groups.Add (myDistance);
		}

		int counter = 0;
		foreach (distance i in groups) {
			counter++;
			if (i.from <= randomNumber && i.to >= randomNumber) {
				result = counter;
				break;
			}

		}

		return result;
	}

	void SpawnByPosition (GameObject gameObject, int position)
	{
		if (gameObject == blockage && position == 1)
			SpawnConcreteObject (blockage, blockageLeft);
		else if (gameObject == blockage && position == 2)
			SpawnConcreteObject (blockage, blockageCenter);
		else if (gameObject == blockage && position == 3)
			SpawnConcreteObject (blockage, blockageRight);
		else if (gameObject == hill && position == 1)
			SpawnConcreteObject (hill, hillLeft);
		else if (gameObject == hill && position == 2)
			SpawnConcreteObject (hill, hillCenter);
		else if (gameObject == hill && position == 3)
			SpawnConcreteObject (hill, hillRight);
		else if (gameObject == hole && position == 1)
			SpawnConcreteObject (hole, holeLeft);
		else if (gameObject == hole && position == 2)
			SpawnConcreteObject (hole, holeCenter);
		else if (gameObject == hole && position == 3)
			SpawnConcreteObject (hole, holeRight);
		
		else if (gameObject == oilTank1 && position == 1)
			SpawnConcreteObject (oilTank1, oilTankLeft);
		else if (gameObject == oilTank1 && position == 2)
			SpawnConcreteObject (oilTank1, oilTankCenter);
		else if (gameObject == oilTank1 && position == 3)
			SpawnConcreteObject (oilTank1, oilTankRight);
		else if (gameObject == oilTank2 && position == 1)
			SpawnConcreteObject (oilTank2, oilTankLeft);
		else if (gameObject == oilTank2 && position == 2)
			SpawnConcreteObject (oilTank2, oilTankCenter);
		else if (gameObject == oilTank2 && position == 3)
			SpawnConcreteObject (oilTank2, oilTankRight);
	}

	void SpawnByPosition (GameObject gameObject)
	{
		if (gameObject == turnLeft)
			SpawnConcreteObject (turnLeft, VturnLeft);
		else if (gameObject == turnRight)
			SpawnConcreteObject (turnRight, VturnRight);
		else if (gameObject == trafficLight)
			SpawnConcreteObject (trafficLight, VtrafficLight);
	}
}