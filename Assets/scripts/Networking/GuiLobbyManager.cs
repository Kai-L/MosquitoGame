using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class GuiLobbyManager : NetworkManager
{
	public Button buttonHuman;
	public Button buttonMosquito;
    NetworkPlayerChoice networkPlayerChoice;

	void Start()
	{
		StartMatchMaker ();
        networkPlayerChoice = GetComponent<NetworkPlayerChoice>();
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

    public void Spawner(int i)
    {
        StartCoroutine(SpawnCharacter(i));
    }

	public IEnumerator SpawnCharacter(int i)
    {
        playerPrefab = networkPlayerChoice.SetCharacter(i);
        yield return new WaitForSeconds(1);
        ClientScene.AddPlayer(client.connection, 0);
        ClientScene.Ready(client.connection);
        yield return new WaitForSeconds(2);
        networkPlayerChoice.CmdNetworkSpawn(playerPrefab);
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
