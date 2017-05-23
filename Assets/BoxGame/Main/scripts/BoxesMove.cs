using UnityEngine;
using System.Collections;

public class BoxesMove : MonoBehaviour
{

	public float speed;
	public bool isStopped;
	public bool wasPicked;

	public bool isCounted;

	public bool isOnLeftConveyer;


	void Update ()
	{
		// до первого поворота
		if (transform.position.x <= -3.8f && transform.position.z <= -5.0f)
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (-3.8f, 1.8f, transform.position.z), speed * 0.1f);	
		// после первого поворота
		else if (!isStopped)
			transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, transform.position.y, -1.0f), speed * 0.1f);
		// левом конвеере
		if (isOnLeftConveyer) {
			transform.Translate (new Vector3 (2, 0, 0) * Time.deltaTime);
		}
			



	}

}



