using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WalkController : NetworkBehaviour {

	public float speed = 10f;

	[Header("Jump Cooldown")]
	private bool jumpUse = true;
	public float forceConst;
	private Rigidbody selfRigidbody;

	void Start () 
	{
		if (isLocalPlayer) {
			this.transform.GetChild (0).gameObject.GetComponent<Camera> ().enabled = true;
			this.transform.GetChild (0).gameObject.GetComponent<AudioListener> ().enabled = true;
		} else {
			this.transform.GetChild (0).gameObject.GetComponent<Camera> ().enabled = false;
			this.transform.GetChild (0).gameObject.GetComponent<AudioListener> ().enabled = false;
		}

		selfRigidbody = GetComponent<Rigidbody> ();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () 
	{

		if (!isLocalPlayer)
		{
			return;
		}

		float translation = Input.GetAxis ("Vertical") * speed;
		float strafe = Input.GetAxis ("Horizontal") * speed;
		translation *= Time.deltaTime;
		strafe *= Time.deltaTime;

		transform.Translate (strafe, 0, translation);

		if (Input.GetKey(KeyCode.Space) && jumpUse == true)
		{
			selfRigidbody.AddForce (0, forceConst, 0, ForceMode.Impulse);
			StartCoroutine(Cooldown());
			jumpUse = false;
		}

		if (Input.GetKeyDown("escape"))
		{
			Cursor.lockState = CursorLockMode.None;
		}

		if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
	}


	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds (3f);
		jumpUse = true;
	}

	public override void OnStartLocalPlayer()
	{
		GetComponentInChildren<SkinnedMeshRenderer> ().enabled = false;
	}
}
