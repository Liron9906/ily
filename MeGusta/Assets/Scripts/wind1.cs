using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind1 : MonoBehaviour
{
    [SerializeField] GameObject windThing;
    System.Random rnd = new System.Random();
    int count = 0;
    bool isAlive = false;
    // Start is called before the first frame update
    bool wind = false;
    void Start()
    {
        StartCoroutine(WeWINDING());
    }
    GameObject windoosh;
    // Update is called once per frame
    void Update()
    {
        if (wind)
        {
            transform.Translate(new Vector3(-1, 0, 0)* Time.deltaTime);
            count++;
            if (count==1)
            {
                 windoosh=
                    Instantiate(windThing, new Vector2(12, -3), Quaternion.identity) as GameObject;
                windoosh.SetActive(true);
                isAlive = true;
                Destroy(windoosh, 6);
                delay();
            }
        }
        if (isAlive)
        {
            windoosh.transform.Translate(new Vector3(-20, 0, 0) * Time.deltaTime);
        }
    }
    IEnumerator WeWINDING()
    {
        while (true)
        {
            wind = !wind;
            yield return new WaitForSeconds(Random.Range(0.4f,1));//length of wind gust
            if (wind == false)
            {
                yield return new WaitForSeconds(Random.Range(3, 10));//delay between gusts
                count = 0;
            }
            count = 0;
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(4);
        isAlive= false;
    }
}
