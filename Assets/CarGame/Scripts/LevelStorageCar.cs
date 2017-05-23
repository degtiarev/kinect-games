using UnityEngine;
using System.Collections;

public class LevelStorageCar : MonoBehaviour 
{
	public int StartLevel = 1;
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}
