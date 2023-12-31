using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Shape : MonoBehaviour
{
    [SerializeField] GameObject endObj;
    [SerializeField] float moveSpeed;
    Vector3 moveVector;
    bool go= false;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 endPos = new Vector3(endObj.transform.position.x, endObj.transform.position.y, endObj.transform.position.z);
        moveVector = (endPos-transform.position).normalized * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            go = true;
        }
        if (go)
        {
            if (FindObjectOfType<L_PrefabScript>().IsOnGrid==false)
            {
                {
                    transform.position += moveVector * Time.deltaTime;
                }
            }
            else
            {
                FindObjectOfType<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
