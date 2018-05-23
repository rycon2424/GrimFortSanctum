using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class NetworkingEnzo : NetworkManager {

	private GameObject keeper;
	private GameObject escapist;
	public bool isKeeper = true;
    public UnityEvent test;

	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log("OnPlayerConnected");
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		if (isKeeper) {
			keeper = Instantiate(Resources.Load("KEEPERBUTTHEREALONE"), new Vector3(2.4f, 1, 9), Quaternion.identity) as GameObject;

			NetworkServer.AddPlayerForConnection(conn, keeper, playerControllerId);
            test.Invoke();
			isKeeper = false;
		}
		else if (!isKeeper)
		{
			escapist = Instantiate(Resources.Load("ESCAPISTBUTTHEREALONE 1"), new Vector3(7.7f, 1, -6.3f), Quaternion.identity) as GameObject;

			NetworkServer.AddPlayerForConnection(conn, escapist, playerControllerId);
			isKeeper = true;
		}

	}

}
