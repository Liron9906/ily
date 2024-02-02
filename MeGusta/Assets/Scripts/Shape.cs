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
   
    // Start is called before the first frame update
    void Start()
    {
        this.tag = "Throwable";
        go = false;
        bopbopbopbopyesyesyesyes = false;
		Vector3 endPos = new Vector3(endObj.transform.position.x, endObj.transform.position.y, endObj.transform.position.z);
    }
	
	// Update is called once per frame
	void Update()
    {
        if (lClickCounter > 0)
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //FindObjectOfType<L_PrefabScript>().pressed = true;
            pressed= true;
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
        if (go)
        {
            if (bopbopbopbopyesyesyesyes==false)
            {
               transform.position += moveVector *moveSpeed* Time.deltaTime;
               Debug.Log("aniHOMO");    
                
            }
            else
            {
                 FindObjectOfType<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
			//go = false;
		}
	}
	private void OnTriggerEnter2D(Collider2D other)//locks throwable to prefab
	{
        if (other.tag == "Wall")
        {
            
        }
		if (other.tag == "Background" && pressed == true)
		{
			if (other.GetComponent<L_PrefabScript>().GetIsOccupied())
			{
				FindObjectOfType<Manager>().SpawnNewOne();
                Destroy(gameObject);

			}
			else//if false
			{
				IsOnGrid = true;
				other.GetComponent<L_PrefabScript>().SetIsOccupied();//sets it to true
				this.tag = "Used";//changes the throwable tag to Used so it wont teleport like crazy between square(personal experience:)
				GetComponent<Transform>().Translate(0, 0, 0);
				GetComponent<Transform>().position = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z - 1);
				GetComponent<SpriteRenderer>().sortingOrder = other.GetComponent<SpriteRenderer>().sortingOrder;
				//Debug.Log((this.transform.position.x, this.transform.position.y, this.transform.position.z - 1));
				bopbopbopbopyesyesyesyes = true;
				FindObjectOfType<Manager>().SpawnNewOne();
                lClickCounter = 0;
				//other.GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
				pressed = false;

			}
		}

	}
}
