using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
	protected GameObject empty;
	protected bool IsOccupied;
	protected float positionx;
	protected float positiony;
	public Tiles(GameObject empty,float positionx,float positiony)
	{
		this.empty = empty;
		this.IsOccupied = false;
		this.positionx = positionx;	
		this.positiony = positiony;
	}
	public bool GetIsOccupied() {  return this.IsOccupied; }
	public float GetPositionx() {  return this.positionx; }
	public float GetPositiony() {  return this.positiony; }
	public void SetPositionx(float x) {  this.positionx = x; }
	public void SetPositiony(float y) {  this.positiony = y; }
	public void SetIsOccupied() {  this.IsOccupied=!this.IsOccupied;Debug.Log(this.IsOccupied); }
	public override string ToString()
	{
		return $"My Position is- ({this.GetPositionx()},{this.GetPositiony()})";
	}
}

