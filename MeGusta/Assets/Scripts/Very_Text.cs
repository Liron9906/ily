using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Very_Text : MonoBehaviour
{

	[SerializeField] string[] anouncmentLines;
	[SerializeField] Text textComponent;
	[SerializeField] GameObject UIComponent;
	[SerializeField] float textSpeed = 0.5f;
	int index;
	float timer;
	bool Called=false;
	private void Update()
	{
		if(timer + 5 < Time.time&&Called)
		{
			textComponent.text = "";
			UIComponent.SetActive(false);
			Called=false;
		}
	}
	public void StartDialogue(string thingstosay)
	{
		index = 0;
		StartCoroutine(TypeLine(thingstosay));
		UIComponent.SetActive(true);

	}
	IEnumerator TypeLine(string str)
	{
		foreach (char c in str.ToCharArray())
		{

			textComponent.text += c;
			yield return new WaitForSeconds(textSpeed);
		}
		destroy();
	}
	void destroy()
	{
		timer= Time.time;
		Called = true;
	}
}
