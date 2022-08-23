using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	
	public void PlayGame()
	{
		SceneManager.LoadScene("LVL1");
	}

	public void QuitGame()
	{
		Debug.Log("Quit");
		Application.Quit();
	}

	public void Instructions()
	{
		SceneManager.LoadScene("Instructions");
	}

	public void GoToCredits()
	{
		SceneManager.LoadScene("Credits");
	}
}
