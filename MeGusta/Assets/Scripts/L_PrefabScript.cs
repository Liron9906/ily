using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class L_PrefabScript : Tiles
{
	[SerializeField] GameObject shapeoosh;
	public bool IsOnGrid = false;
	public L_PrefabScript(int id) : base(id) { }

    private void Awake()
    {

    }

    private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shapeoosh.layer = 0; //com
        }
    }
	private void OnTriggerEnter2D(Collider2D other)//locks throwable to prefab
	{
		if (other.tag == "Throwable")
		{
			if (this.GetIsOccupied())
			{

				
			}
			else//if false
			{
                IsOnGrid = true;
                this.SetIsOccupied();//sets it to true
				other.tag = "Used";//changes the throwable tag to Used so it wont teleport like crazy between square(personal experience:)
				other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
				other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
				other.GetComponent<Transform>().position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-1);
			}
		}

	}
	//public void BonkGrid(GameObject other)
	//{
	//	this.SetIsOccupied();
	//	other.tag = "Used";
	//	//locks throwable to prefab
	//	//gets the shape and  the direction
	//	//
	//	other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
	//	Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
	//	other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
	//	//other.GetComponent<Transform>().position = new Vector3(this.transform.position.x,this.transform.position.y,this.transform.position.z-1);
	//	IsOnGrid = false;
	//}
}