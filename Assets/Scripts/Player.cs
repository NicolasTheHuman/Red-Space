using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Player : MonoBehaviour
{
	public float moveSpeed = 600f;
	float movement = 0f;

	public SpriteRenderer sr;
	public Color greenColor;
	public Color blueColor;
	public Color whiteColor;

	public GameObject blueSquare;
	public GameObject greenSquare;

	public float currentTime;
	float maxColorTime = 1f;

	public Image lifeBarHUD;
	public float currentLife;
	public float maxLife = 3f;

	public Image bulletTimeHUD;
	public float currentBulletTime;
	public float maxBulletTime = 1f;

	public static bool defeat = false;
	public GameObject defeatMenuUI;

	// Start is called before the first frame update
    void Start()
    {
		currentLife = maxLife;
		currentBulletTime = maxBulletTime;
    }

	// Update is called once per frame
	void Update()
	{
		movement = Input.GetAxisRaw("Horizontal");

		ColorSwitch();

		currentTime += Time.deltaTime;

		if (Input.GetKey(KeyCode.Space) && currentBulletTime > 0)
		{
			currentBulletTime -= Time.unscaledDeltaTime;
			bulletTimeHUD.fillAmount = currentBulletTime / maxBulletTime;
			Time.timeScale = .5f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	private void FixedUpdate()
	{
		transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);
	}

	void ColorSwitch()
	{
		if (Input.GetKeyDown(KeyCode.Q) || Input.GetMouseButtonDown(0))
		{
			sr.color = Color.green;
			gameObject.tag = "Green";
			currentTime = 0f;
		}
		else if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(1))
		{
			sr.color = Color.blue;
			gameObject.tag = "Blue";
			currentTime = 0f;
		}
		else if(currentTime >= maxColorTime)
		{
			sr.color = Color.white;
			gameObject.tag = "Untagged";
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == LayerMask.NameToLayer("GreenSquare"))
		{
			if(gameObject.tag != "Green")
			{
				currentLife--;
			}

		}
		else if (collision.gameObject.layer == LayerMask.NameToLayer("BlueSquare"))
		{
			if(gameObject.tag != "Blue")
			{
				currentLife--;
			}
		}
		else if(collision.gameObject.layer == LayerMask.NameToLayer("Buff") && collision.gameObject.tag == "Health")
		{
			Destroy(collision.gameObject);
			if(currentLife < maxLife)
			{
				currentLife++;
			}

			if(currentLife == 2)
			{
				lifeBarHUD.color = Color.yellow;
			}
			else if(currentLife == maxLife)
			{
				lifeBarHUD.color = Color.green;
			}
		}
		else if(collision.gameObject.layer == 12 && collision.gameObject.tag == "Time")
		{
			Destroy(collision.gameObject);
			currentBulletTime = maxBulletTime;
			bulletTimeHUD.fillAmount = currentBulletTime / maxBulletTime;
		}
		else
		{
			currentLife--;
		}


		lifeBarHUD.fillAmount = currentLife / maxLife;
		if (lifeBarHUD.fillAmount <= 0.8f)
		{
			if (lifeBarHUD.fillAmount <= 0.4f)
			{
				lifeBarHUD.color = Color.red;
			}
			else
			{
				lifeBarHUD.color = Color.yellow;
			}

		}

		if (currentLife <= 0f)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
