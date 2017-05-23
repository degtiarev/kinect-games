using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class BoxGameGameController : MonoBehaviour
{
	public  UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text levelText;

	const string levelST = "Уровень: ";
	const string scoreST = "Счет: ";

	public int score;
	public int level;
	public float time=0.0f;

	// Use this for initialization
	void Start ()

	{

		DontDestroyOnLoad(gameObject);

		try {
			GameObject level1 = GameObject.Find ("Level");
			BoxGameLevelStorage levelStorage = level1.GetComponent<BoxGameLevelStorage> ();
			level = levelStorage.StartLevel;


			GameObject spawns = GameObject.Find ("Spawns");
			Spawner spawner = spawns.GetComponent<Spawner> ();
			spawner.boxSpeed =0.3f+0.1f*level;

		} catch {
		}


		
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.loadedLevelName != "score") {
			scoreText.text = scoreST + score;
			levelText.text = levelST + level;

			if (score == 7) {

				GameObject spawns = GameObject.Find ("Spawns");
				Spawner spawner = spawns.GetComponent<Spawner> ();
				spawner.boxSpeed += 0.1f;

				level++;
				score = 0;
			}


			if (level == 10) {

				Application.LoadLevel ("score");
			}
		

			time += Time.deltaTime;

			if (Input.GetKeyDown (KeyCode.Q))
			Application.LoadLevel ("score");
		}

	
	}

}
