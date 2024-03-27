using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    [SerializeField] int speed = 100;
    [SerializeField] GameObject pivot;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        if (FindObjectOfType<skillCheck>().stopSpin == false)
        {
            transform.RotateAround(pivot.transform.position, new Vector3(0, 0, 1), speed * Time.deltaTime);
        }
        else if (timer + 3 < Time.deltaTime)
        {
            FindObjectOfType<skillCheck>().stopSpin = true;
        }
    }
}
