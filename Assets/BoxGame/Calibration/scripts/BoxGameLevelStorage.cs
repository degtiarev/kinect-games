using UnityEngine;
using System.Collections;

public class BoxGameLevelStorage : MonoBehaviour 
{
	public int StartLevel = 1;
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}
