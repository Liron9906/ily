using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject[] rotations= new GameObject[4];
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("NEGAWHAT");


            i++;
            if (i>3)
            {
                i = 0;
            }
            if (i<0)
            {
                i = 3;
            }
            Manager.Throwable = rotations[i];
            Debug.Log(i);
        }
    }
}
