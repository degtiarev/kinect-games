using UnityEngine;
using System.Collections;

public class ShuttleGameLevelStorage : MonoBehaviour 
{
	public int StartLevel = 1;
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}
