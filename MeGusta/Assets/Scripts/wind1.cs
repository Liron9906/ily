using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind1 : MonoBehaviour
{
    [SerializeField] GameObject windThing;
    // Start is called before the first frame update
    bool wind = false;
    void Start()
    {
        StartCoroutine(WeWINDING());
    }

    // Update is called once per frame
    void Update()
    {
        if (wind)
        {
            transform.Translate(new Vector3(-1, 0, 0)* Time.deltaTime);
            GameObject windoosh =
                Instantiate(windThing, new Vector2(0, 0), Quaternion.identity) as GameObject;
            windoosh.GetComponent<Rigidbody2D>().velocity = new Vector2(-40,0)*Time.deltaTime;
            Destroy(windoosh,1.5f);
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
            }
        }
    }
}
