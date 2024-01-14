using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGuy : MonoBehaviour
{
	[SerializeField] int PlayerSpeed = 5;
	Vector3 Movement = new Vector3 (0, 0, 0);

	private void Update()
	{
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Movement = new Vector2(0, PlayerSpeed);
			transform.Translate(Movement*Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Movement = new Vector2(0, -PlayerSpeed);
			transform.Translate(Movement * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Movement = new Vector2(-PlayerSpeed, 0);
			transform.Translate(Movement * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Movement = new Vector2(PlayerSpeed, 0);
			transform.Translate(Movement * Time.deltaTime);
		}
		
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Used")
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Player";
			//gameObject.layer = LayerMask.NameToLayer("Player");
			Debug.Log(GetComponent<SpriteRenderer>().sortingLayerName);
		}
		else
		{
			GetComponent<SpriteRenderer>().sortingLayerName = "Background";
			//gameObject.layer = LayerMask.NameToLayer("Background");
			Debug.Log(gameObject.layer);

		}
		//Debug.Log(gameObject.layer);
		

	}
}
