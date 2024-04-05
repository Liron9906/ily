using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Rendering;

public class Shape : MonoBehaviour
{
	//[SerializeField] GameObject shapeoosh;
	
	public bool isLockedOnGrid;
    [SerializeField] GameObject endObj;
    [SerializeField] float moveSpeed=5;
    Vector3 moveVector;
    bool go= false;
    bool pressed= false;

	public bool IsLeftPressed=false;
    Color firstColor;
	// Start is called before the first frame update
	void Start()
    {
        this.tag = "Throwable";
        this.go = false;
        this.isLockedOnGrid = false;
		FindObjectOfType<Manager>().FindMousePos();
    }
	private void Awake()
	{
		IsLeftPressed = false;
	}
	// Update is called once per frame
	void Update()
    {
		MovetoMouseDir();
        InputButBetter();

	}
	private void OnTriggerEnter2D(Collider2D other)//locks throwable to prefab
	{
        if (other.tag == "Background")
        {

		}

		if (other.tag == "Wall")
        {
			FindObjectOfType<Manager>().SpawnNewOne();
			Destroy(gameObject);
			IsLeftPressed = false;

		}
		if (other.tag == "Background" && pressed == true)
        {


			if (other.GetComponent<L_PrefabScript>().GetIsOccupied())
            {


            }
            else//if false
            {
				
                other.GetComponent<L_PrefabScript>().SetIsOccupied();//sets it to true
				FindObjectOfType<Manager>().SpawnNewOne();

				this.tag = "Used";//changes the throwable tag to Used so it wont teleport like crazy between square(personal experience:)
				this.GetComponent<Transform>().Translate(0, 0, 0);
				this.GetComponent<Transform>().position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 1);
				this.GetComponent<SpriteRenderer>().sortingOrder = other.GetComponent<SpriteRenderer>().sortingOrder;
				//Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
				this.isLockedOnGrid = true;
				IsLeftPressed = false;

				//other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
				this.pressed = false;

			}
        }
	}
	private void OnTriggerExit2D(Collider2D other)
	{

	}
    private void InputButBetter()
    {
		//if (Input.GetKeyDown(KeyCode.R)) { GetComponent<Transform>().Rotate(new Vector3(0, 0, 90)); }
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			//FindObjectOfType<L_PrefabScript>().pressed = true;
			pressed = true;
			//shapeoosh.layer = 0; //com

		}
		//Vector3 endPos = new Vector3(endObj.transform.position.x, endObj.transform.position.y, endObj.transform.position.z);    
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if (!IsLeftPressed&& !this.isLockedOnGrid)
			{
				FindObjectOfType<Manager>().TimesSpawned[Y_LeftUI.id - 1]--;
				FindObjectOfType<Manager>().CountPrint();
				FindObjectOfType<Manager>().ColorChange();

				moveVector = (endObj.transform.position - transform.position).normalized;
				pressed = false;
				IsLeftPressed = true;

				go = true;
			}
			
		}
	}

	private void MovetoMouseDir()
	{
		if (go)
		{
			if (this.isLockedOnGrid == false)
			{
				transform.position += moveVector * moveSpeed * Time.deltaTime;
				

			}
			else
			{
				FindObjectOfType<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			}
			//go = false;
		}
	}
}
