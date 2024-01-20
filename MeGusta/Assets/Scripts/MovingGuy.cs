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

    private void Update()
	{
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Movement = new Vector2(0, PlayerSpeed);
			transform.Translate(Movement*Time.deltaTime);
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
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Used" || other.tag =="start" || other.tag == "end")//diversified to 3 different tags in case we wanna mess with the usage of the "Used" tag
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Player";
			//gameObject.layer = LayerMask.NameToLayer("Player");
			Debug.Log(gameObject.layer);

		}
		else
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";
			//gameObject.layer = LayerMask.NameToLayer("Background");
			Debug.Log(gameObject.layer);
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1; //makes bro fall 
		}
		//Debug.Log(gameObject.layer);
		

	}
}
