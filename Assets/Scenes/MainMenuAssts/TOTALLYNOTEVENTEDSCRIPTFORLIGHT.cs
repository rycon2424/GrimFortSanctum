using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOTALLYNOTEVENTEDSCRIPTFORLIGHT : MonoBehaviour {

	public GameObject lamp;

	void Start () 
	{
		StartCoroutine(Off());
	}

	IEnumerator Off()
	{
		lamp.SetActive (true);
		yield return new WaitForSeconds (Random.Range(1, 1.5f));
		lamp.SetActive (false);
		yield return new WaitForSeconds (Random.Range(0.5f, 1));
		lamp.SetActive (true);
		yield return new WaitForSeconds (Random.Range(0.1f, 0.4f));
		lamp.SetActive (false);
		yield return new WaitForSeconds (Random.Range(0.1f, 0.4f));
		lamp.SetActive (true);
		yield return new WaitForSeconds (Random.Range(0.1f, 0.4f));
		lamp.SetActive (false);
		yield return new WaitForSeconds (Random.Range(1, 2));
		StartCoroutine (Off ());
	}

}
