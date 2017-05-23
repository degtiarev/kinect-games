using UnityEngine;
using System.Collections;

public class CanvasSettings : MonoBehaviour {

	private GameObject a;
	private GameObject b;
	private GameObject c;
	private GameObject d;
	private GameSettings gs;
	private LevelStorage lv;
	private TimeScript ts;
	private MySimpleVisualGestureListener MV;
	public UnityEngine.UI.Text AllScoreText;
	public UnityEngine.UI.Text TimeText;
	public UnityEngine.UI.Text LevelText;
	private string St1 = "Лёгкий";
	private string St2 = "Средний";
	private string St3 = "Тяжёлый";
	private string St = "";
	// Use this for initialization
	void Start () {
	
		level ();
		ts = b.GetComponent<TimeScript> ();
		lv = c.GetComponent<LevelStorage> ();
		gs = a.GetComponent<GameSettings>();


	}
	
	// Update is called once per frame
	void Update () {

		AllScoreText.text = "Все очки: " + GameSettings.AllScore;
		TimeText.text = "Время: " + TimeScript.timeString;

	}

	void level(){
		GameObject score = GameObject.Find ("Level");
		LevelStorage levelStorage= score.GetComponent<LevelStorage>();

		if  (levelStorage.StartLevel == 1) LevelText.text = "Уровень сложности: " + St1;
		else if (levelStorage.StartLevel == 3) LevelText.text = "Уровень сложности: " + St2;
		else if (levelStorage.StartLevel == 4) LevelText.text = "Уровень сложности: " + St3;
		else LevelText.text = "Уровень сложности: " + St;


	}

	void UpdateLevel (){


	}

	public void OnGUI () {
		if (GUI.Button (new Rect (25, 700, 200, 30), "Выход")) {
			Application.Quit();
		}
		if (GUI.Button (new Rect (300, 700, 200, 30), "Вернуться к калибровке")) {
			Application.LoadLevel("calibration");
			GameSettings.AllScore = 0;
		}

	}
}
