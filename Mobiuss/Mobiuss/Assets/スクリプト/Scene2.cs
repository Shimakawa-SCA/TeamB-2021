using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour
{
	int count;
	void Start()
    {
		count = 0;
    }
	void Update()
	{
		if (count == 0 && Input.GetKeyDown("joystick button 1"))
		{
			count++;
			Invoke("Loadpuro", 2.0f);
		}
	}
		// Use this for initialization
		public void OnClick()
	{
		Invoke("Loadpuro", 2.0f);
	}

	void Loadpuro()
    {
		SceneManager.LoadScene("SampleScene");
	}
}