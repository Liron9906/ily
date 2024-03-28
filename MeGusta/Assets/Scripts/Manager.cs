using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	[SerializeField] GameObject endObj2;
	[SerializeField] public static GameObject Throwable;
	public int skillCheckCount;
	public static Vector3 throwableSpawnPoint = new Vector3(-8, -2, 10);
	public static bool destroyThatBitch= false;
    [SerializeField] Sprite openCage;
	[SerializeField] GameObject Cage;
	[SerializeField] GameObject finalDoor;
    [SerializeField] GameObject finalDoorNew;

    private void Update()
    {
		//Throwable = Y_LeftUI.curTile;
		//Debug.Log(Throwable);
		skillCheckCount = skillCheck.countOfHits;
		if (skillCheck.countOfHits == 3)
		{
			destroyThatBitch = true;
			Cage.GetComponent<SpriteRenderer>().sprite = openCage;
			cage.isOver = true;
			finalDoor.GetComponent<SpriteRenderer>().sprite = finalDoorNew.GetComponent<SpriteRenderer>().sprite;
        }
    }
	private void Start()
	{
		Throwable= FindObjectOfType<Y_LeftUI>().curTiles[0];
		SpawnNewOne();
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
			Instantiate(Throwable, throwableSpawnPoint, Quaternion.identity) as GameObject;
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
