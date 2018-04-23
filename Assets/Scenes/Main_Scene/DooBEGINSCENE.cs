using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DooBEGINSCENE : MonoBehaviour {

	public static bool cellGate = false;
	public static bool haveKey = false;
	bool doOnce = true;
	bool startRotating = false;

    public GameObject door1;
    public GameObject door2;
	
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
            door1.transform.localRotation = new Quaternion(0, 0.707f, 0, 0.707f);
            door2.transform.localRotation = new Quaternion(0, 0.707f, 0, 0.707f);
        }
    }

	IEnumerator openGate()
	{
		startRotating = true;
		yield return new WaitForSeconds (1.5f);
		startRotating = false;
	}

}
