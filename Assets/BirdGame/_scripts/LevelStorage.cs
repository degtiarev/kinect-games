using UnityEngine;
using System.Collections;

public class LevelStorage : MonoBehaviour 
{
	public int StartLevel = 1;
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}
