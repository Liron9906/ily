using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MovingGuy : MonoBehaviour
{
	[SerializeField] int PlayerSpeed = 5;
	Vector3 Movement = new Vector3(0, 0, 0);
	[SerializeField] Sprite front;
	[SerializeField] Sprite back;
	[SerializeField] Sprite left;
	[SerializeField] Sprite right;
	[SerializeField] Sprite falling;
	bool isFall = false;
	bool didClick = false;
	private void Start()
	{

		//Announcment.GetComponent<Text>().text = "" ;
	}
	private void Update()
	{
		if (Input.GetKey(KeyCode.Mouse0))//see explanation below
		{
			didClick = true;
		}
		if (isFall == false)//locks movement when falling (visual shtick)
		{
			if (Input.GetKey(KeyCode.W))
			{
				Movement = new Vector2(0, PlayerSpeed);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = back;
				GetComponent<AudioSource>().Play();
			}
			if (Input.GetKey(KeyCode.S))
			{
				Movement = new Vector2(0, -PlayerSpeed);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = front;
				GetComponent<AudioSource>().Play();

			}
			if (Input.GetKey(KeyCode.A))
			{
				Movement = new Vector2(-PlayerSpeed, 0);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = left;
				GetComponent<AudioSource>().Play();

			}
			if (Input.GetKey(KeyCode.D))
			{
				Movement = new Vector2(PlayerSpeed, 0);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = right;
				GetComponent<AudioSource>().Play();
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "donesies")
		{
			SceneManager.LoadScene("closing");
		}
		if (other.tag == "donez")
		{
			SceneManager.LoadScene("L2");
		}
		if (other.tag == "PickUpSlim")
		{
			Y_LeftUI.isSlimUnlocked = true;
			announcment("Slim");
			Destroy(other);
		}//SlimPickUP
		if (other.tag == "PickUpSquare")
		{
			Y_LeftUI.isSquareUnlocked = true;
			announcment("Square");
			Destroy(other);
		}//Square PickUp
		if (other.tag == "PickUpLShape")
		{
			Y_LeftUI.isLshapeUnlocked = true;
			announcment("LShape");
			Destroy(other);
		}//L Shape PickUp

		if (other.tag == "PickUpPlus")
		{
			Y_LeftUI.isPlusUnlocked = true;
			announcment("Plus");
			Destroy(other);
		}   // i dont know what shape its gonna be tbh
		if (other.tag != "Background" && other.tag != "bounds")//diversified to 4 different tags in case we wanna mess with the usage of the "Used" tag
		{
			if (gameObject.GetComponent<Renderer>().sortingLayerID != SortingLayer.NameToID("FALLING"))
			{
				gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("Player");//working sorting layer change
																									 //gameObject.layer = LayerMask.NameToLayer("Player");
																									 //Debug.Log(gameObject.layer);
			}
		}
		else
		{
			if (didClick)//this exists because of inconsistencies (of unclear origins) before and after the click causing gravity to go goofy
			{
				GetComponent<Rigidbody2D>().gravityScale = 25f; //makes bro fall 
			}
			else
			{
				GetComponent<Rigidbody2D>().gravityScale = 2f; //makes bro fall 
			}
			isFall = true;
			gameObject.GetComponent<SpriteRenderer>().sprite = falling;
			gameObject.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("FALLING");//working sorting layer change
			StartCoroutine(SceneLoader(FindObjectOfType<Manager>().thisSceneName, 3));
			//gameObject.layer = LayerMask.NameToLayer("Background");
			//Debug.Log(gameObject.layer);

		}
		//Debug.Log(gameObject.layer);


	}
	public void announcment(string shape)
	{
		switch (shape)
		{
			case "LShape":
				FindObjectOfType<Very_Text>().StartDialogue("+3 L Shapes has UnLocked!");
				FindObjectOfType<Manager>().TimesSpawned[2] = FindObjectOfType<Manager>().TimesSpawned[2] + 3;

				break;
			case "Slim":
				FindObjectOfType<Very_Text>().StartDialogue("+3 slim has unlocked!");
				FindObjectOfType<Manager>().TimesSpawned[3] = FindObjectOfType<Manager>().TimesSpawned[3] + 3;

				break;
			case "Square":
				FindObjectOfType<Very_Text>().StartDialogue("+1 Square has unlocked!");
				FindObjectOfType<Manager>().TimesSpawned[0] = FindObjectOfType<Manager>().TimesSpawned[0] + 1;

				break;
			case "Plus":
				FindObjectOfType<Very_Text>().StartDialogue("+ 2 Plus has unlocked!");
				FindObjectOfType<Manager>().TimesSpawned[1] = FindObjectOfType<Manager>().TimesSpawned[1] + 3;
				break;
		}
		FindObjectOfType<Manager>().CountPrint();
		FindObjectOfType<Manager>().ColorChange();


	}

	public static IEnumerator SceneLoader(string sceneName, float timeToWait)
	{
		yield return new WaitForSeconds(timeToWait);
		SceneManager.LoadScene(sceneName);
	}
}
