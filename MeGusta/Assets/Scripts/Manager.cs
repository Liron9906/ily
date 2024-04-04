using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public int[] TimesSpawned = new int[4];//0- slim 1-L 2-plus 3-Square
	[SerializeField] Text[] TextComponent= new Text[4];
	
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
		TimesSpawned[0] = 5;
		Throwable= FindObjectOfType<Y_LeftUI>().curTiles[0];
		SpawnNewOne();
	}
	public void SpawnNewOne()
	{
		Debug.Log(Y_LeftUI.id);
		if (TimesSpawned[Y_LeftUI.id-1] > 0)
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
				Instantiate(Throwable, throwableSpawnPoint, Quaternion.identity) as GameObject;
				Throwable = ThrowableGO;
				ThrowableGO.SetActive(true);

			}
			TimesSpawned[Y_LeftUI.id - 1]--;
			for (int i = 0; i < TimesSpawned.Length; i++)
			{
					
			}
		}
		else
		{
			if (isEmpty())
			{
				//FindObjectOfType<Very_Text>().StartDialogue("OUT OF TILES");
				GetComponent<Very_Text>().StartDialogue("OUTOFTILES");
			}
		}
	}
	public Vector3 FindMousePos()
	{
		Vector3 endPos = new Vector3(endObj2.transform.position.x, endObj2.transform.position.y, endObj2.transform.position.z);
		return endPos;
	}	
	public bool isEmpty()
	{
		for (int i = 0; i < TimesSpawned.Length; i++)
		{
			if (TimesSpawned[i] > 0)
			{
				return false;
			}

		}
		return true;
	}
}
