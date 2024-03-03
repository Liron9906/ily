using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind1 : MonoBehaviour
{
    // Start is called before the first frame update

    bool isWind = true;
    float timer;
    void Start()
    {
        timer = Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (timer + 3 < Time.deltaTime)
        {
            isWind = true;
            transform.Translate(new Vector2(-5, 0) * Time.deltaTime); 
            timer = Time.deltaTime;
            isWind = false;
        }
    }
}
