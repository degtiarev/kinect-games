using UnityEngine;
using System.Collections;

class Span
{
	float from;
	float to;

	public Span (float from, float to)
	{
		this.from = from;
		this.to = to;
	}

	public float From {
		get { return from;}
		set { from = value;}
	}

	public float To {
		get { return to;}
		set { to = value;}
	}

	public bool isBelong (float number)
	{
		if (number > from && number <= to) 
			return true;
		else 
			return false;
	}
}

class Position
{
	public float X{ get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public Position (float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}

public class SpawnScript : MonoBehaviour
{

	public GameObject earth;
	public GameObject star;
	public GameObject cubes;
	public GameObject pumpkin;
	public GameObject stump;
	public float frequency;
	private float nextSomething = 0.0f;
	private float spawnRate = 2f;
	private Position upStar;
	private Position middleStar;
	private Position downStar;

	void Start ()
	{
		upStar = new Position (-0.842f, 1.244f, 0.18f);
		middleStar = new Position (0.214f, 0.978f, 0.18f);
		downStar = new Position (0.302f, -0.016f, 0.18f);
	}

	void Update ()
	{
		if (nextSomething < Time.time) {
			SpawnSomething ();
			nextSomething = Time.time + spawnRate;
			
			//Speed up the spawnrate for the next item
			//spawnRate *= 0.98f;
			//spawnRate = Mathf.Clamp (spawnRate, 0.3f, 99f);
		}
	}
	
	void SpawnSomething ()
	{
		bool isSpawnObstacle = false;
		bool isSpawnBonus = false;
		string respawnedItem = "";
		float elementChooser;
		float choose;

		if (Random.Range (0.0f, frequency) < frequency / 2.0f)
			isSpawnObstacle = true;

		if (Random.Range (0.0f, frequency) < frequency / 2.0f)
			isSpawnBonus = true;

		if (isSpawnObstacle) {
			if (frequency % 4 == 0)
				elementChooser = frequency;
			else
				elementChooser = frequency * 4;

			Span Scubes = new Span (0.0f, (float)0.25 * elementChooser);
			Span Spumpkin = new Span ((float)0.25 * elementChooser, (float)0.5 * elementChooser);
			Span SStump = new Span ((float)0.5 * elementChooser, (float)0.75 * elementChooser);
//			Span SPumplinAndStump = new Span ((float)0.75 * elementChooser, elementChooser);

			choose = Random.Range (0.0f, elementChooser);

			if (Scubes.isBelong (choose)) {
				SpawnConcreteObject (cubes);
				respawnedItem = "cubes";
			} else if (Spumpkin.isBelong (choose)) {
				SpawnConcreteObject (pumpkin);
				respawnedItem = "pumpkin";
			} else if (SStump.isBelong (choose)) {
				SpawnConcreteObject (stump);
				respawnedItem = "stump";
			} else {
				SpawnConcreteObject (pumpkin);
				SpawnConcreteObject (stump);
				respawnedItem = "stumpAndPumpkin";
			}
		}

		if (isSpawnBonus) {

			if (!isSpawnObstacle) {
				if (frequency % 3 != 0)
					elementChooser = frequency * 3;
				else
					elementChooser = frequency;

				choose = Random.Range (0.0f, elementChooser);
				Span upScreen = new Span (0.0f, elementChooser * 0.33f);
//				Span middleScreen = new Span (elementChooser * 0.33f, elementChooser * 0.66f);
				Span downScreen = new Span (0.66f * elementChooser, elementChooser);
			
				choose = Random.Range (0.0f, elementChooser);

				if (downScreen.isBelong (choose)) {
					SpawnConcreteObject (star, downStar);
				} else if (upScreen.isBelong (choose)) {
					SpawnConcreteObject (star, upStar);
				} else {
					SpawnConcreteObject (star, middleStar);
				}
			} 

			else 
			{
				if (respawnedItem == "stumpAndPumpkin")
					SpawnConcreteObject (star, middleStar);
				else if (respawnedItem == "cubes")
					SpawnConcreteObject (star, upStar);
				else if (respawnedItem=="pumpkin")
				{
					elementChooser=frequency;
					choose= Random.Range(0.0f, elementChooser);
//					Span middleScreen =new Span(0.0f, 0.5f*elementChooser);
					Span downScreen = new Span(0.5f*elementChooser, elementChooser);

					if (downScreen.isBelong(choose))
						SpawnConcreteObject (star, downStar);
					else
						SpawnConcreteObject(star, upStar);
				}
				else 
				{
					elementChooser=frequency;
					choose= Random.Range(0.0f, elementChooser);
					Span middleScreen =new Span(0.0f, 0.5f*elementChooser);
//					Span upScreen = new Span(0.5f*elementChooser, elementChooser);

					if (middleScreen.isBelong(choose))
						SpawnConcreteObject (star, middleStar);
					else
						SpawnConcreteObject(star, upStar);
				}

			}

		}


	}

	void SpawnConcreteObject (GameObject gameObject)
	{
		Vector3 spawnPos = transform.position + new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Quaternion prefQuart = new Quaternion (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
		GameObject prefab = Instantiate (gameObject, spawnPos, prefQuart) as GameObject;
		prefab.transform.parent = earth.transform;

	}

	void SpawnConcreteObject (GameObject gameObject, Position forPlus)
	{
		Vector3 spawnPos = transform.position + new Vector3 (gameObject.transform.position.x + forPlus.X, gameObject.transform.position.y + forPlus.Y, gameObject.transform.position.z + forPlus.Z);
		Quaternion prefQuart = new Quaternion (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
		GameObject prefab = Instantiate (gameObject, spawnPos, prefQuart) as GameObject;
		prefab.transform.parent = earth.transform;
		
	}

}