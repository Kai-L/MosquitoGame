using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class GuiLobbyManager : NetworkManager
{
	public string onlineStatus;

	void Start()
	{

	}

	void OnLevelWasLoaded()
	{
		
	}

	// ----------------- Server callbacks ------------------

	public override void OnStopHost()
	{

	}

	// ----------------- Client callbacks ------------------

	public override void OnClientConnect(NetworkConnection conn)
	{

	}

	public override void OnClientError(NetworkConnection conn, int errorCode)
	{
		StopHost();
	}

	public override void OnClientDisconnect(NetworkConnection conn)
	{

	}

	public override void OnStartClient(NetworkClient client)
	{
		if (matchInfo != null)
		{

		}
		else
		{

		}
	}
}
