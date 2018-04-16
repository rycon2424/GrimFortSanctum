using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooBEGINSCENE : MonoBehaviour {

	public static bool cellGate = false;
	public static bool haveKey = false;
	bool doOnce = true;
	bool startRotating = false;
	
	// Update is called once per frame
	void Update () 
	{
		if (cellGate == true && doOnce == true)
		{
			StartCoroutine(openGate());
			doOnce = false;
		}

		if (startRotating == true) 
		{
			transform.Rotate (new Vector3 (0, 2, 0));
		}
	}

	IEnumerator openGate()
	{
		startRotating = true;
		yield return new WaitForSeconds (1.5f);
		startRotating = false;
	}

}
