using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class endObj : MonoBehaviour
{
    public bool IsOnBorders = false;

	// Start is called before the first frame update
	void Start()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "NIB")
        {
			Debug.Log("das");
			IsOnBorders = true;
        }
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "NIB")
		{
			Debug.Log("das");
			IsOnBorders = false;
		}
	}
	// Update is called once per frame
	void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -9);
        if (IsOnBorders && Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
    }
}
