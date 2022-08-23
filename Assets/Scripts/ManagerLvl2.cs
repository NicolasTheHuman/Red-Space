using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerLvl2 : MonoBehaviour
{
	public Text HUDTimer;
	float currentTime;
	float maxTime = 30f;

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
		HUDTimer.text = "Time: " + (int)currentTime + " / " + (int)maxTime;
		Victory();
    }

	public void Victory()
	{
		if(currentTime >= 30f)
		{
			SceneManager.LoadScene("LVL3");
		}
	}
}
