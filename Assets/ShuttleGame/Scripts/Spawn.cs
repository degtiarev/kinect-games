using UnityEngine;
using System.Collections;

class SGSpan
{
	float from;
	float to;

	public SGSpan (float from, float to)
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

class SGPosition
{
	public float X{ get; set; }

	public float Y { get; set; }

	public float Z { get; set; }

	public SGPosition (float x, float y, float z)
	{
		X = x;
		Y = y;
		Z = z;
	}
}

public class Spawn : MonoBehaviour {

	public GameObject ring;
	public GameObject star;
	public GameObject meteo1;
	public GameObject meteo2;
	public GameObject meteoObstracle1;
	public GameObject meteoObstracle2;
	public float frequency;
	private float nextSomething = 0.0f;
	private float spawnRate = 2f;
	//private SGPosition StarUp;
	private SGPosition StarMiddle;
	//private SGPosition StarDown;
	private SGPosition StarLeft;
	private SGPosition StarRight;
	private SGPosition MeteoMiddle;
	private SGPosition MeteoRand;


	void Start ()
	{
		//StarUp = new SGPosition (0f, 60f, 0f);
		StarMiddle = new SGPosition (0f, 30f, 0f);
		//StarDown = new SGPosition (0f, 0f, 0f);
		StarLeft = new SGPosition (0f, 30f, -70f);
		StarRight = new SGPosition (0f, 30f, 60f);
		MeteoMiddle = new SGPosition (0f, 30f, 0f);
	}

	void Update ()
	{
		if (nextSomething < Time.time) {
			SpawnSomething ();
			nextSomething = Time.time + spawnRate;
		}
	}

	void CreateRandomMeteo (){

		string respawnedItem = "";

		if (Random.Range (0, frequency) < frequency / 2) {
			SpawnConcreteObject (meteo1, new SGPosition (Random.Range (-200f, -300f), Random.Range (0f, 30f), Random.Range (0f, 100f)));//именно тут можно задать две точки
			respawnedItem = "Meteo1";
		} else {
			SpawnConcreteObject (meteo2, new SGPosition (Random.Range (100f, 200f), Random.Range (0f, 50f), Random.Range (0f, -70f)));
			respawnedItem = "Meteo2";
		}
	}




	void SpawnSomething ()
	{
		bool isSpawnObstacle = false;
		bool isSpawnBonus = false;
		string respawnedItem = "";
		float elementChooser;
		float choose;
		CreateRandomMeteo ();

		if (Random.Range (0.0f, frequency) < frequency / 2.0f)//если случайная величина меньше уполовиненной величины создаём препятствие

			//в 50 процентах случаев

			isSpawnObstacle = true;

		if (Random.Range (0.0f, frequency) < frequency / 2.0f)
			isSpawnBonus = true;

		if (isSpawnObstacle) {
			//CreateRandomMeteo ();
			if (frequency % 4 == 0)
				elementChooser = frequency;
			else
				elementChooser = frequency * 4;

			SGSpan smeteoObstracle1 = new SGSpan (0.0f, (float)0.25 * elementChooser);
			SGSpan smeteoObstracle2 = new SGSpan ((float)0.25 * elementChooser, (float)0.5 * elementChooser);
			SGSpan ObstracleAndObstracle = new SGSpan ((float)0.75 * elementChooser, elementChooser);

			choose = Random.Range (0.0f, elementChooser);

			if (smeteoObstracle1.isBelong (choose)) {
				SpawnConcreteObject (meteoObstracle1, MeteoMiddle);
				respawnedItem = "Meteo3";
			} else if (smeteoObstracle2.isBelong (choose)) {
				SpawnConcreteObject (meteoObstracle2);
				respawnedItem = "Meteo4";
			} else {
				//SpawnConcreteObject (meteoObstracle1);
				SpawnConcreteObject (meteoObstracle2);
				respawnedItem = "meteo3andmeteo4";
			}
		}

		if (isSpawnBonus) {

			if (!isSpawnObstacle) {
				if (frequency % 3 != 0)
					elementChooser = frequency * 3;
				else
					elementChooser = frequency;

				//choose = Random.Range (0.0f, elementChooser);
				choose = Random.Range (0.0f, elementChooser * 0.66f);
				SGSpan middleScreen = new SGSpan (0.66f * elementChooser, elementChooser);
				//SGSpan leftScreen = new SGSpan (0.0f, elementChooser * 0.66f);
				SGSpan leftScreen = new SGSpan (0.66f * elementChooser, elementChooser);
				SGSpan rightScreen = new SGSpan (0.0f, elementChooser * 0.66f);

				choose = Random.Range (0.0f, elementChooser);

				if (leftScreen.isBelong (choose)) {
					SpawnConcreteObject (star, StarLeft);
				} else if (rightScreen.isBelong (choose)) {
					SpawnConcreteObject (star, StarRight);
				} else {
					SpawnConcreteObject (star, StarMiddle);
				}
			} 

			else 
			{
				if (respawnedItem == "meteo3andmeteo4")//если звезда находится на кубах, то она идёт сверху
					SpawnConcreteObject (star,StarMiddle);
				else if (respawnedItem == "Meteo3")
					SpawnConcreteObject (star, StarLeft);
				else if (respawnedItem == "Meteo3")
					SpawnConcreteObject (star, StarRight);
				else if (respawnedItem=="Meteo3")//если на тыкве, то снизу
				{
					elementChooser=frequency;
					choose= Random.Range(0.0f, elementChooser);
					SGSpan downScreen = new SGSpan(0.5f*elementChooser, elementChooser);
				}
				else 
				{
					elementChooser=frequency;
					choose= Random.Range(0.0f, elementChooser);
					SGSpan middleScreen =new SGSpan(0.0f, 0.5f*elementChooser);

					if (middleScreen.isBelong(choose))
						SpawnConcreteObject (star, StarMiddle);
				}

			}

		}


	}


	void SpawnConcreteObject (GameObject gameObject)
	{
		Vector3 spawnPos = transform.position + new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		Quaternion prefQuart = new Quaternion (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
		GameObject prefab = Instantiate (gameObject, spawnPos, prefQuart) as GameObject;
		prefab.transform.parent = ring.transform;

	}

	void SpawnConcreteObject (GameObject gameObject, SGPosition forPlus)
	{
		Vector3 spawnPos = transform.position + new Vector3 (gameObject.transform.position.x +  forPlus.X, gameObject.transform.position.y + forPlus.Y, gameObject.transform.position.z + forPlus.Z);
		Quaternion prefQuart = new Quaternion (gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);
		GameObject prefab = Instantiate (gameObject, spawnPos, prefQuart) as GameObject;
		prefab.transform.parent = ring.transform;

	}
}

