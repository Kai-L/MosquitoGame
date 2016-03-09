using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

	public GameObject networkMenu;
	public GameObject characterMenu;

	public void LoadMainMenu(){
		SceneManager.LoadScene ("Menu_Main");
	}

	public void LoadLobby(){
		SceneManager.LoadScene ("Menu_NetworkSelect");
	}

	public void ExitGame(){
		Application.Quit ();
	}

	public void TempLoadGame(){
		SceneManager.LoadScene ("Week8_Prototype");
	}

	public void CloseCharacterSelect(){
		networkMenu.SetActive (true);
		characterMenu.SetActive (false);

	}

	public void OpenCharacterSelect(){
		networkMenu.SetActive (false);
		characterMenu.SetActive (true);
	}

	public void CloseLobby(){
		networkMenu.SetActive (false);
		characterMenu.SetActive (false);
	}

	public void ShowWinScreen(){

	}

	public void ShowLoseScreen(){

	}

}
