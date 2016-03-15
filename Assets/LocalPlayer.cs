using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LocalPlayer : NetworkBehaviour {

	GuiLobbyManager lobbyManager;
	NetworkPlayerChoice networkPlayerChoice;
	public GameObject localPlayer;

	bool localPlayerChecked = false;

	void Start(){
		lobbyManager = FindObjectOfType<GuiLobbyManager> ();
		networkPlayerChoice = FindObjectOfType<NetworkPlayerChoice> ();
	}

	void Update(){
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

}
