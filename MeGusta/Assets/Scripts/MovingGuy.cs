using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class MovingGuy : MonoBehaviour
{
	[SerializeField] int PlayerSpeed = 5;
	Vector3 Movement = new Vector3(0, 0, 0);
	[SerializeField] Sprite front;
	[SerializeField] Sprite back;
	[SerializeField] Sprite left;
	[SerializeField] Sprite right;
	[SerializeField] Sprite falling;
	[SerializeField] GameObject Announcment;	
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
			if (Input.GetKey(KeyCode.UpArrow))
			{
				Movement = new Vector2(0, PlayerSpeed);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = back;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				Movement = new Vector2(0, -PlayerSpeed);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = front;
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				Movement = new Vector2(-PlayerSpeed, 0);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = left;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				Movement = new Vector2(PlayerSpeed, 0);
				transform.Translate(Movement * Time.deltaTime);
				gameObject.GetComponent<SpriteRenderer>().sprite = right;
			}
		}
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "PickUpSlim") { Y_LeftUI.isSlimUnlocked = true; GetComponent<AudioSource>().Play(); announcment("Slim"); Destroy(other); }//SlimPickUP
		if (other.tag == "PickUpSquare") { Y_LeftUI.isSquareUnlocked = true; GetComponent<AudioSource>().Play();announcment("Square") ; Destroy(other); }//Square PickUp
		if (other.tag == "PickUpLShape") { Y_LeftUI.isLshapeUnlocked = true; GetComponent<AudioSource>().Play(); announcment("LShape") ; Destroy(other); }//L Shape PickUp
		if (other.tag == "PickUpPlus") { Y_LeftUI.isPlusUnlocked = true; GetComponent<AudioSource>().Play(); announcment("Plus") ; Destroy(other); }	// i dont know what shape its gonna be tbh
		if (other.tag != "Background")//diversified to 4 different tags in case we wanna mess with the usage of the "Used" tag
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
			//gameObject.layer = LayerMask.NameToLayer("Background");
			Debug.Log(gameObject.layer);

        }
		//Debug.Log(gameObject.layer);
		
		
	}
	public void announcment(string shape)
	{
		switch (shape)
		{
			case "LShape":
				FindObjectOfType<Very_Text>().StartDialogue("L Shape has unlocked!");
				break;
			case "Slim":
				FindObjectOfType<Very_Text>().StartDialogue("slim has unlocked!");
				break;
			case "Square":
				FindObjectOfType<Very_Text>().StartDialogue("Square has unlocked!");
				break;
			case "Plus":
				FindObjectOfType<Very_Text>().StartDialogue("Plus has unlocked!");
				break;
		}
	}
}
