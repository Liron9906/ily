using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] int x=6;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0);   
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
       
        x = -x;
		GetComponent<Rigidbody2D>().velocity = new Vector2(x, 0); 
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
