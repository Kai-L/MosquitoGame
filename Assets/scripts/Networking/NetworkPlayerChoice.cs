using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerChoice : NetworkBehaviour {

	public GameObject[] characters;
	public int currentI;

	bool hasSwapped = false;

	public GameObject SetCharacter(int i)
	{
        return characters[i];
        //GetComponent<GuiLobbyManager> ().playerPrefab = characters [i];
        /*
        if (i == 0) {
			currentI = 1;
		} else {
			currentI = 0;
		}
        */
    }

    [Command]
    public void CmdNetworkSpawn(GameObject playerPrefab)
    {
        Debug.Log("Spawning " + playerPrefab.name);
        NetworkServer.SpawnWithClientAuthority(playerPrefab, connectionToClient);
    }

}
