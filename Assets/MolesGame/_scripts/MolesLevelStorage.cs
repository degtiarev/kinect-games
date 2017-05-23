using UnityEngine;
using System.Collections;

public class MolesLevelStorage : MonoBehaviour 
{
	public int StartLevel = 1;
	void Start ()
	{
		DontDestroyOnLoad(gameObject);
	}

}
