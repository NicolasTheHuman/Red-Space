using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerLvl1 : MonoBehaviour
{
	public Text HUDTimer;

	float currentTime;
	float maxTime = 15f;

	// Update is called once per frame
	void Update()
	{
		currentTime += Time.deltaTime;
		HUDTimer.text = "Time: " + (int)currentTime + " / " + (int)maxTime;
		Victory();
	}

	public void Victory()
	{
		if (currentTime >= 15f)
		{
			SceneManager.LoadScene("LVL2");
		}
	}
}
