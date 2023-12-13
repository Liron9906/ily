using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class L_PrefabScript : Tiles
{
	public L_PrefabScript(int id) : base(id) { }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Throwable")
		{
			if (this.GetIsOccupied())
			{

				
			}
			else//if false
			{
				this.SetIsOccupied();
				other.tag = "Used";
				//locks throwable to prefab
				//gets the shape and  the direction
				//
				other.GetComponent<Rigidbody2D>().velocity= new Vector2(0,0);
				Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
				other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z-1);
				//other.GetComponent<Transform>().position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-1);
				
				//sets it to true
			}
		}
	}
}