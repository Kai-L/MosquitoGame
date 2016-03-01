using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonFunctions : MonoBehaviour {

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

}
