using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetworkSync : NetworkBehaviour 
{

	public Clock clock;

	public List<GameObject> PlayersInGame;

    LocalPlayer localPlayer;

    bool humanAdded = false;
	bool mosquitoAdded = false;

	public int playersRequired = 2;

	void Start(){
        localPlayer = FindObjectOfType<LocalPlayer>();
		StartCoroutine (CheckPlayerCount ());
	}

	IEnumerator CheckPlayerCount()
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null && !humanAdded) 
		{
			AddToPlayers(GameObject.FindGameObjectWithTag("Player"));
			humanAdded = true;
		}
		if (GameObject.FindGameObjectWithTag ("mosquito") != null && !mosquitoAdded) 
		{
			AddToPlayers (GameObject.FindGameObjectWithTag ("mosquito"));
			mosquitoAdded = true;
		}

		yield return new WaitForSeconds (0);

		if (PlayersInGame.Count != playersRequired) {
			StartCoroutine (CheckPlayerCount ());
		} else {
			clock.StartCoroutine (clock.TickSecond ());
            GameObject.Find("WaitingScreen").SetActive(false);
            localPlayer.AllowMovement();
		}
	}

	public void AddToPlayers (GameObject player)
	{
		PlayersInGame.Add (player);
	}
}
