using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
	public int[] TimesSpawned = new int[4];//0- slim 1-L 2-plus 3-Square
	[SerializeField] Text[] TextComponent= new Text[4];
	[SerializeField] GameObject[] tilespictures;

	[SerializeField] GameObject endObj2;
	[SerializeField] public static GameObject Throwable;
	[SerializeField] public int baseNumOfTiles = 5;
	public int skillCheckCount;
	public static Vector3 throwableSpawnPoint = new Vector3(-8, -2, 10);
	public static bool destroyThatBitch= false;
    [SerializeField] Sprite openCage;
	[SerializeField] GameObject Cage;
	[SerializeField] GameObject finalDoor;
    [SerializeField] GameObject finalDoorNew;
	[SerializeField] AudioClip doorSound;
	Color[] ogcolor = new Color[4];
	public string thisSceneName;


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
			AudioSource.PlayClipAtPoint(doorSound, Camera.main.transform.position);
        }
    }
	private void Start()
	{
		Scene sin = SceneManager.GetActiveScene();
		thisSceneName = sin.name;
		for (int i = 0; i < tilespictures.Length; i++)
		{
			ogcolor[i] = tilespictures[i].GetComponent<Image>().color;

		}
		TimesSpawned[0] = baseNumOfTiles;
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
		}
		else
		{
			if (isEmpty())
			{
				//FindObjectOfType<Very_Text>().StartDialogue("OUT OF TILES");
				GetComponent<Very_Text>().StartDialogue("OUTOFTILES");
				StartCoroutine( MovingGuy.SceneLoader(thisSceneName, 3));

			}
		}
		CountPrint();
		ColorChange();
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
	public void ColorChange()
	{
		if (TimesSpawned[0] > 0)
		{
			tilespictures[0].GetComponent<Image>().color = ogcolor[0];

		}
		else
		{
			ogcolor[0] = tilespictures[0].GetComponent<Image>().color;
			tilespictures[0].GetComponent<Image>().color = Color.gray;
		}
		if (TimesSpawned[1] > 0)
		{
			tilespictures[1].GetComponent<Image>().color = ogcolor[1];

		}
		else
		{
			ogcolor[1] = tilespictures[1].GetComponent<Image>().color;
			tilespictures[1].GetComponent<Image>().color = Color.gray;
		}
		if (TimesSpawned[2] > 0)
		{
			tilespictures[2].GetComponent<Image>().color = ogcolor[2];

		}
		else
		{
			ogcolor[2] = tilespictures[0].GetComponent<Image>().color;
			tilespictures[2].GetComponent<Image>().color = Color.gray;
		}
		if (TimesSpawned[3] > 0)
		{
			tilespictures[3].GetComponent<Image>().color = ogcolor[3];

		}
		else
		{
			ogcolor[3] = tilespictures[3].GetComponent<Image>().color;
			tilespictures[3].GetComponent<Image>().color = Color.gray;
		}
	}
	public void CountPrint()
	{
		for (int i = 0; i < TimesSpawned.Length; i++)
		{
			TextComponent[i].text = TimesSpawned[i].ToString();
		}
	}
	public void respawn(GameObject input)
	{
		if (!FindObjectOfType<Shape>().IsLeftPressed)//if left click isnt pressed
		{
			GameObject temp;
			Destroy(Throwable);
			temp = Instantiate(input, throwableSpawnPoint, Quaternion.identity) as GameObject;
			Throwable = temp;
			Throwable.SetActive(true);

		}
		else
		{
			Throwable = input;
		}
	}
}
