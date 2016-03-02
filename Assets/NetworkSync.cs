using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class NetworkSync : NetworkBehaviour 
{

	public Clock clock;

	public List<GameObject> PlayersInGame;

	bool humanAdded = false;
	bool mosquitoAdded = false;

	void Start(){
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

		yield return new WaitForSeconds (1);

		if (PlayersInGame.Count != 2) {
			StartCoroutine (CheckPlayerCount ());
		} else {
			clock.StartCoroutine (clock.TickSecond ());
		}
	}

	public void AddToPlayers (GameObject player)
	{
		PlayersInGame.Add (player);
	}
}
