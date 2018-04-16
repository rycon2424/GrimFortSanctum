using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoomManager : MonoBehaviour {

	public float rotationSpeed;
	public int timeBeforeRotation;
	public bool startRotating = false;
	public GameObject spikes;

	int randomizer;

	void Start () 
	{
		spikes.SetActive (false);
		//dit moet op een trigger
		StartCoroutine(RotationStart());
		randomizer = Random.Range (1, 3);
	}

	void Update () 
	{
		if (startRotating == true && randomizer == 1) 
		{
			transform.Rotate (new Vector3 (0, 0, rotationSpeed) * Time.deltaTime );
		}

		if (startRotating == true && randomizer == 2) 
		{
			transform.Rotate (new Vector3 (0, 0, -rotationSpeed) * Time.deltaTime );
		}
	}

	IEnumerator RotationStart()
	{
		yield return new WaitForSeconds (timeBeforeRotation);
		spikes.SetActive (true);
		startRotating = true;
	}

}
