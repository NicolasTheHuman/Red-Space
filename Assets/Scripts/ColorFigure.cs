using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFigure : MonoBehaviour
{
	public Rigidbody2D rb;

	public float shrinkSpeed = 3f;

	public LineRenderer lr;
	public string currentColor;
	public Color greenColor;
	public Color blueColor;

	public 
	
	// Start is called before the first frame update
	void Start()
	{
		rb.rotation = Random.Range(0f, 361f);
		transform.localScale = Vector3.one * 10f;

		ColorChange();
	}

	// Update is called once per frame
	void Update()
	{
		transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

		if (transform.localScale.x <= 0.5f)
		{
			Destroy(gameObject);
		}
	}

	void ColorChange()
	{
		int index = Random.Range(0, 2);

		switch (index)
		{
			case 0:
				currentColor = "Green";
				lr.startColor = Color.green;
				lr.endColor = Color.green;
				break;
			case 1:
				currentColor = "Blue";
				lr.startColor = Color.blue;
				lr.endColor = Color.blue;
				break;
		}
		if(currentColor == "Green")
		{
			transform.gameObject.tag = "Green";
		}
		else if(currentColor == "Blue")
		{
			transform.gameObject.tag = "Blue";
		}
	}
}
