using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuy : MonoBehaviour
{
	[SerializeField] int PlayerSpeed = 5;
	Vector3 Movement = new Vector3 (0, 0, 0);
	[SerializeField] Sprite front;
    [SerializeField] Sprite back;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
	[SerializeField] Sprite falling;
	bool isFall = false;
	bool didClick = false;
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
}
