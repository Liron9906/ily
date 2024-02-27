using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Presets;
using UnityEngine;
using UnityEngine.Rendering;

public class Shape : MonoBehaviour
{
	//[SerializeField] GameObject shapeoosh;
	public bool IsOnGrid = false;
	public bool bopbopbopbopyesyesyesyes;
    [SerializeField] GameObject endObj;
    [SerializeField] float moveSpeed=5;
    Vector3 moveVector;
    bool go= false;
    bool pressed= false;
    int lClickCounter= 0;
    Color firstColor;
	// Start is called before the first frame update
	void Start()
    {
        this.tag = "Throwable";
        go = false;
        bopbopbopbopyesyesyesyes = false;
		FindObjectOfType<Manager>().FindMousePos();
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
			////Color gridColor = new Color(25, 255, 0, 0.2605f);
   //         firstColor = other.GetComponent<SpriteRenderer>().color;
			//other.GetComponent<SpriteRenderer>().color = firstColor;
		}

		if (other.tag == "Wall")
        {
			FindObjectOfType<Manager>().SpawnNewOne();
			Destroy(gameObject);


		}
		if (other.tag == "Background" && pressed == true)
        {


			if (other.GetComponent<L_PrefabScript>().GetIsOccupied())
            {


            }
            else//if false
            {
				this.IsOnGrid = true;
                other.GetComponent<L_PrefabScript>().SetIsOccupied();//sets it to true
                this.tag = "Used";//changes the throwable tag to Used so it wont teleport like crazy between square(personal experience:)
				FindObjectOfType<Manager>().SpawnNewOne();
				this.GetComponent<Transform>().Translate(0, 0, 0);
                this.GetComponent<Transform>().position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 1);
                this.GetComponent<SpriteRenderer>().sortingOrder = other.GetComponent<SpriteRenderer>().sortingOrder;
                //Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
                this.bopbopbopbopyesyesyesyes = true;
                this.lClickCounter = 0;
                //other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                this.pressed = false;

            }
        }
	}
	private void OnTriggerExit2D(Collider2D other)
	{
        if (other.tag == "Background")
        {
			//other.GetComponent<SpriteRenderer>().color = firstColor;
		}
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
			if (lClickCounter == 0)
			{
				moveVector = (endObj.transform.position - transform.position).normalized;

			}
			pressed = false;
			lClickCounter++;
			go = true;
		}
	}

	private void MovetoMouseDir()
	{
		if (go)
		{
			if (bopbopbopbopyesyesyesyes == false)
			{
				transform.position += moveVector * moveSpeed * Time.deltaTime;
				Debug.Log("aniHOMO");

			}
			else
			{
				FindObjectOfType<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
			}
			//go = false;
		}
	}
}
