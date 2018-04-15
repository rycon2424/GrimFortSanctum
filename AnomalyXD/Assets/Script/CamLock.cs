using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CamLock : NetworkBehaviour {

	Vector2 mouseLook;
	Vector2 smoothV;
    RaycastHit hit;

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


        Ray myRay = new Ray(transform.position, transform.forward);

        Debug.DrawRay(transform.position, transform.forward * 3.5f);


        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(myRay, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("TypeUwTagHier"))
            {
                //maak hier het event als je de tag raakt
            }
        }
    }
}
