using UnityEngine;
using UnityEngine.Networking;
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
                if (localPlayer.GetComponent<SleepyMovement>().isAlive == false)
                {
                    localLoss(localPlayer);
                }
            }
            else if(localPlayer.tag == "mosquito")
            {
                if (localPlayer.GetComponent<MosquitoControl>().isAlive == false)
                {
                    localLoss(localPlayer);
                }
            }
        }

		if (localPlayerChecked) 
		{
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

    IEnumerator WaitThenStop()
    {
        FindObjectOfType<SleepyMovement>().enabled = false;
        FindObjectOfType<MosquitoControl>().enabled = false;
        yield return new WaitForSeconds(3);
        lobbyManager.StopClient();
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        lobbyScreen.SetActive(true);
    }
}
