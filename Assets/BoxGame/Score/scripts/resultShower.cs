using UnityEngine;
using System.Collections;

public class resultShower : MonoBehaviour {


	public  GUIText Text;

	// Use this for initialization
	void Start () {


			


	
	}
	
	// Update is called once per frame
	void Update () {

		try {

		GameObject gameObjectGameController = GameObject.Find ("GameController");
			BoxGameGameController scriptGameController = gameObjectGameController.GetComponent<BoxGameGameController> ();

		float allTime=scriptGameController.time;

		int minutes= (int)   (allTime/60.0f);
		int seconds=(int) (allTime - (minutes*60.0f));

		//Text.text="Общее время: "+minutes+":"+seconds+"\nДостигнутный уровень: "+scriptGameController.level+"\nНабрано очков: "+scriptGameController.score;
			Text.text="Счет: "+scriptGameController.score + "\nУровень: "+scriptGameController.level+ "\nВремя игры:\n"+"\t" +minutes+" мин "+seconds + " сек";
		}

		catch{
		}


	
	}
}
