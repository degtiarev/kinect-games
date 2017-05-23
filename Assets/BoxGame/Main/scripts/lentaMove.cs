using UnityEngine;
using System.Collections;

public class lentaMove : MonoBehaviour
{

	public float scrollSpeed;
	Renderer rend;

	// Use this for initialization
	void Start ()
	{
		rend = GetComponent<Renderer> ();
	}


	// Update is called once per frame
	void Update ()
	{
		repeateOffset ();
	}


	void repeateOffset ()
	{
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, offset));
		rend.material.SetTextureOffset ("_BumpMap", new Vector2 (0, offset));
	}
}
