using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;

public class KeeperAnim : /*NetworkBehaviour*/ MonoBehaviour {

	private Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		
		/*if (!isLocalPlayer)
		{
			return;
		}*/

		if (Input.GetKey(KeyCode.W))
		{
			anim.SetInteger ("State", 1);
		}

		if (Input.GetKey(KeyCode.S))
		{
			anim.SetInteger ("State", 2);
		}

		if (Input.GetKey(KeyCode.A))
		{
			anim.SetInteger ("State", 3);
		}

		if (Input.GetKey(KeyCode.D))
		{
			anim.SetInteger ("State", 4);
		}

		if (Input.GetKey(KeyCode.Space))
		{
			anim.SetInteger ("State", 5);
		}

		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || 
			Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.S) || (Input.GetKeyUp(KeyCode.Space)))
		{
			anim.SetInteger ("State", 0);
		}

	}
}
