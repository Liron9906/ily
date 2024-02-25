using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject[] rotations= new GameObject[4];
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("NEGAWHAT");


            count++;
            if (count >3)
            {
                count = 0;
            }
            if (count<0)
            {
                count = 3;
            }
            //Manager.Throwable = rotations[count];
            Debug.Log(count);
        }
    }
}
