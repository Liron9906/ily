using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	[SerializeField] GameObject endObj2;
	[SerializeField] public static GameObject Throwable;
    private void Update()
    {
		//Throwable = Y_LeftUI.curTile;
		//Debug.Log(Throwable);
    }
    public void SpawnNewOne()
	{
		if (FindObjectOfType<endObj>().IsOnBorders)
		{
			GameObject ThrowableGO =
			Instantiate(Throwable, FindMousePos(), Quaternion.identity) as GameObject;
			Throwable = ThrowableGO;
			ThrowableGO.SetActive(true);
		}
		else
		{
			GameObject ThrowableGO =
			Instantiate(Throwable, new Vector3(-8,-1,10), Quaternion.identity) as GameObject;
			Throwable = ThrowableGO;
            ThrowableGO.SetActive(true);
        }
    }
	public Vector3 FindMousePos()
	{
		Vector3 endPos = new Vector3(endObj2.transform.position.x, endObj2.transform.position.y, endObj2.transform.position.z);
		return endPos;
	}	
}
public class Throwable : MonoBehaviour
{
	Dir facing;
	bool unlocked;
	GameObject sprite;
	public Throwable(GameObject sprite)
	{
		this.facing = Dir.F;
		this.unlocked = false;
		this.sprite = sprite;
	}
	public Throwable()
	{
		this.facing = Dir.F;
		this.unlocked = false;
		this.sprite=null;
	}
	public void ChangeDir(Dir dir)
	{
		this.facing = dir;
		
	}
	private void Update()
	{
		if (this.facing == Dir.F)
		{
			
		}
	}
}
public enum Dir { F, B,L,R }