using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerChoice : MonoBehaviour {

	public GameObject[] characters;
	private int currentI;

	bool hasSwapped = false;

	public void SetCharacter(int i)
	{
		GetComponent<GuiLobbyManager> ().playerPrefab = characters [i];
		currentI = i;
	}

	void Update()
	{
		
	}
}
