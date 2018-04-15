using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtensEvent : MonoBehaviour {

	public GameObject startGame;
	//public GameObject keeper;
	//public GameObject escapist;

	void Start()
	{
		//keeper.SetActive (false);
		//escapist.SetActive (false);
		startGame.SetActive (true);
	}

	public void OnStartGame()
	{
		startGame.SetActive (false);
		SceneManager.LoadScene (1);
		//keeper.SetActive (true);
		//escapist.SetActive (true);
	}
}
