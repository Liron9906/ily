using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
	[SerializeField] GameObject endObj2;
	[SerializeField] public static GameObject Throwable;
	public int skillCheckCount;
    private void Update()
    {
		//Throwable = Y_LeftUI.curTile;
		//Debug.Log(Throwable);
		skillCheckCount = skillCheck.countOfHits;
    }
    public void SpawnNewOne()
	{
		if (FindObjectOfType<endObj>().IsOnBorders)
		{
			GameObject ThrowableGO =
			Instantiate(Throwable, FindMousePos(), Quaternion.identity) as GameObject;
			ThrowableGO.SetActive(true);
			Throwable = ThrowableGO;

		}
		else
		{

			GameObject ThrowableGO =
			Instantiate(Throwable, new Vector3(-8, -1, 10), Quaternion.identity) as GameObject;
			ThrowableGO.SetActive(true);
			Throwable = ThrowableGO;

		}
	}
	public Vector3 FindMousePos()
	{
		Vector3 endPos = new Vector3(endObj2.transform.position.x, endObj2.transform.position.y, endObj2.transform.position.z);
		return endPos;
	}	
}
