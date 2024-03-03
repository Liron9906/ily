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
            GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + new Vector2(-30, 0);
            timer = Time.deltaTime;
            isWind = false;
        }
    }
}
