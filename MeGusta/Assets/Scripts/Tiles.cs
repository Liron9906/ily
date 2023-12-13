using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
	
	protected bool IsOccupied;
	int id;
	public Tiles(int id)
	{
		this.IsOccupied = false;
		this.id = id;
	}
	public Tiles()
	{
		this.IsOccupied = false;
		this.id = 0;
	}
	public bool GetIsOccupied() {  return this.IsOccupied; }

	public int GetID() { return this.id; }
	public void SetIsOccupied() {  this.IsOccupied=!this.IsOccupied;Debug.Log(this.IsOccupied); }
	public override string ToString()
	{
		return $"My ID- ({this.GetID()})";
	}
	//public bool GetIsOccupied()
	//{
		
	//}
	}

