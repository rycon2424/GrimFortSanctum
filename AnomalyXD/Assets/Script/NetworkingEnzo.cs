using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkingEnzo : NetworkManager {

	private GameObject keeper;
	private GameObject escapist;
	public bool isKeeper = true;

	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log("OnPlayerConnected");
	}

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		if (isKeeper) {
			keeper = Instantiate(Resources.Load("KEEPERBUTTHEREALONE"), transform.position, Quaternion.identity) as GameObject;

			NetworkServer.AddPlayerForConnection(conn, keeper, playerControllerId);
			isKeeper = false;
		}
		else if (isKeeper == false)
		{
			escapist = Instantiate(Resources.Load("KEEPERBUTTHEREALONE"), transform.position, Quaternion.identity) as GameObject;

			NetworkServer.AddPlayerForConnection(conn, escapist, playerControllerId);
			isKeeper = true;
		}

	}

}
