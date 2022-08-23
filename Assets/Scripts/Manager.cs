using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
	public Text HUDTimer;

	float currentTime;
	float maxTime = 60f;
	
    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
		HUDTimer.text = "Time: " + (int)currentTime + " / " + (int)maxTime;
		Victory();
	}

	public void Victory()
	{
		if(currentTime >= 60f)
		{
			SceneManager.LoadScene("Victory");
		}
	}
}
