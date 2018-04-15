using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamLock : NetworkBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
	public float sensitivity = 5f;
	public float smoothing = 0.5f;
	public GameObject camera;

	GameObject character;

	void Start () 
	{
		if (!isLocalPlayer)
		{
			return;
		}
		character = this.transform.gameObject;
		camera = this.gameObject.transform.GetChild (0).gameObject;
	}

	void Update () 
	{
		if (!isLocalPlayer)
		{
			return;
		}
		var md = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		md = Vector2.Scale (md, new Vector2 (sensitivity * smoothing, sensitivity * smoothing));
		smoothV.x = Mathf.Lerp (smoothV.x, md.x, 1f / smoothing);
		smoothV.y = Mathf.Lerp (smoothV.y, md.y, 1f / smoothing);
		mouseLook += smoothV;
		mouseLook.y = Mathf.Clamp(mouseLook.y, -60f, 60f);

		camera.transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		character.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, character.transform.up);
	}
}
