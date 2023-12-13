using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
				//locks throwable to prefab
				//gets the shape and  the direction
				//
				this.SetIsOccupied();//sets it to true
			}
		}
	}
}