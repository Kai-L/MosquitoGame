using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerChoice : MonoBehaviour {

	public GameObject[] characters;
	private int currentI;

	bool hasSwapped = false;

	public void SetCharacter(int i)
	{
		GetComponent<NetworkManager> ().playerPrefab = characters [i];
		currentI = i;
	}

	void Update()
	{
		if (GetComponent<NetworkManager> ().isNetworkActive && !hasSwapped) {
			if (currentI == 0) {
				SetCharacter (1);
			} else {
				SetCharacter (0);
			}
			hasSwapped = true;
		}
	}
}
