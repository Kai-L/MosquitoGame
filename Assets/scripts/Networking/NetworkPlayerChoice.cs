using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerChoice : MonoBehaviour {

	public GameObject[] characters;
	public int currentI;

	bool hasSwapped = false;

	public void SetCharacter(int i)
	{
		GetComponent<GuiLobbyManager> ().playerPrefab = characters [i];
		if (i == 0) {
			currentI = 1;
		} else {
			currentI = 0;
		}
	}
}
