using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Shape : MonoBehaviour
{
    public bool bopbopbopbopyesyesyesyes;
    [SerializeField] GameObject endObj;
    [SerializeField] float moveSpeed=5;
    Vector3 moveVector;
    bool go= false;
   
    // Start is called before the first frame update
    void Start()
    {

		Vector3 endPos = new Vector3(endObj.transform.position.x, endObj.transform.position.y, endObj.transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    // Update is called once per frame
    void Update()
    {
		//Vector3 endPos = new Vector3(endObj.transform.position.x, endObj.transform.position.y, endObj.transform.position.z);    
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
			moveVector = (endObj.transform.position - transform.position).normalized;
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
}
