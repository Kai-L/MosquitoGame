﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class LocalPlayer : NetworkBehaviour {

	GuiLobbyManager lobbyManager;
	NetworkPlayerChoice networkPlayerChoice;
	public GameObject localPlayer;

	bool localPlayerChecked = false;

    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject lobbyScreen;

	void Start(){
		lobbyManager = FindObjectOfType<GuiLobbyManager> ();
		networkPlayerChoice = FindObjectOfType<NetworkPlayerChoice> ();
	}

	void Update(){
        if(localPlayer != null)
        {
            if(localPlayer.tag == "Player")
            {
                Destroy(GameObject.FindWithTag("MosquitoCam"));
                if (localPlayer.GetComponent<SleepyMovement>().isAlive == false)
                {
                    localLoss(localPlayer);
                }
            }
            else if(localPlayer.tag == "mosquito")
            {
                Destroy(GameObject.FindWithTag("MainCamera"));
                if (localPlayer.GetComponent<MosquitoControl>().isAlive == false)
                {
                    localLoss(localPlayer);
                }
            }
        }

		if (localPlayerChecked) 
		{
			if (localPlayer == null)
			{
				WaitThenStop ();
			}
			return;
		}

        if (localPlayer != null)
        {
            // This means the local player is Mosquito.
            if (localPlayer.GetComponent<SleepyMovement>() == null)
            {
                lobbyManager.playerPrefab = networkPlayerChoice.characters[0];
                localPlayerChecked = true;
            }
            // This means the local player is Sleepy.
            else
            {
                lobbyManager.playerPrefab = networkPlayerChoice.characters[1];
                localPlayerChecked = true;
            }
        }
	}

    public void localWin(GameObject winner)
    {
        if (winner == localPlayer)
        {
            winScreen.SetActive(true);
            StartCoroutine(WaitThenStop());
        }
    }

    public void localLoss(GameObject loser)
    {
        if (loser == localPlayer)
        {
            loseScreen.SetActive(true);
            StartCoroutine(WaitThenStop());
        }
    }

    public void allLoss()
    {
        loseScreen.SetActive(true);
        StartCoroutine(WaitThenStop());
    }
		
	public delegate void EndGameDelegate();

	[SyncEvent]
	public event EndGameDelegate EventEndGame;

	[Command]
	public void CmdDoEnd(){
		EventEndGame ();
	}

	public void EndGame(){
		lobbyManager.StopClient ();
		lobbyManager.StopMatchMaker ();
		SceneManager.LoadScene ("SwatTheBug");
	}


    IEnumerator WaitThenStop()
    {
        FindObjectOfType<SleepyMovement>().enabled = false;
        FindObjectOfType<MosquitoControl>().enabled = false;
        yield return new WaitForSeconds(3);
        //lobbyManager.StopClient();
		//lobbyManager.StopMatchMaker();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
		//SceneManager.LoadScene ("SwatTheBug");

		EventEndGame += EndGame;

		lobbyManager.StopClient ();
		lobbyManager.StopMatchMaker ();
		SceneManager.LoadScene ("SwatTheBug");

        lobbyScreen.SetActive(true);
    }

    public void AllowMovement()
    {
        if (localPlayer.tag == "Player")
        {
            localPlayer.GetComponent<SleepyMovement>().canMove = true;
            localPlayer.GetComponent<SleepySwat>().canSwat = true;
        }
        else if (localPlayer.tag == "mosquito")
        {
            localPlayer.GetComponent<MosquitoControl>().canMove = true;
        }
    }
}
