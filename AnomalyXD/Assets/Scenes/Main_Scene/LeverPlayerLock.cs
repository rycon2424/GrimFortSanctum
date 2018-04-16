using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LeverPlayerLock : NetworkBehaviour {

    public bool pulledDown;

    public float delay = 1f;

    public GameObject door1;
    public GameObject door2;

    public Quaternion door1OpenQuaternion;
    public Quaternion door2OpenQuaternion;

    public Quaternion door1ClosedQuaternion;
    public Quaternion door2ClosedQuaternion;

    void Start () {
        PullingUp();
	}
	
    public void PullingUp()
    {
        pulledDown = false;
        transform.localRotation = new Quaternion(-0.259f, 0, 0, 0.966f);
        door1.transform.localRotation = door1ClosedQuaternion;
        door2.transform.localRotation = door2ClosedQuaternion;
    }

    public  void PullingDown()
    {
        pulledDown = true;
        transform.localRotation = new Quaternion(0.259f, 0, 0, 0.966f);
        door1.transform.localRotation = door1OpenQuaternion;
        door2.transform.localRotation = door2OpenQuaternion;
        StartCoroutine(PulledBackUp());
    }

    IEnumerator PulledBackUp()
    {
        yield return new WaitForSeconds(delay);
        PullingUp();
    }
}