using UnityEngine;
using System.Collections;

public class PingPongAnimation : MonoBehaviour {

	public float start ;
	public float finish ;

	public string direction;

	// Use this for initialization
	void Start () {

		start = transform.position.y;
		finish = start + 0.15f;

		direction="up";	
	}

	// Update is called once per frame
	void Update () {
	
		if (transform.position.y >= finish)
			direction = "down";
				if(transform.position.y<=start)
			direction="up";

		if(direction=="up")
			transform.Translate(Vector3.forward * Time.deltaTime*0.1f);
		if(direction=="down")
			transform.Translate(Vector3.back * Time.deltaTime*0.1f);
		
	}
}
