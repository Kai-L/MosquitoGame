using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class GuiLobbyManager : NetworkManager
{
	public Button buttonHuman;
	public Button buttonMosquito;

	void Start()
	{
		StartMatchMaker ();
	}

	public void BeginHost()
	{
		StartClient ();
		matchMaker.CreateMatch (matchName, matchSize, true, "", OnMatchCreate);
	}

	public void BeginJoin()
	{
		if (matches == null) {
			matchMaker.ListMatches (0, 20, "", OnMatchList);
		}
	
		matchName = matches[0].name;
		matchSize = (uint)matches[0].currentSize;
		matchMaker.JoinMatch (matches[0].networkId, "", OnMatchJoined);
	}

	public void ClientReady(){
		ClientScene.Ready (client.connection);
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
