using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	
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
			//sprite.transform.right=
		}
	}
}
public enum Dir { F, B,L,R }