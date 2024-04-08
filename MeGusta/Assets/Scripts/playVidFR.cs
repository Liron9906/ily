using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVidFR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayVid1()
    {
        FindObjectOfType<playTutorialVideo>().canvas.gameObject.SetActive(false);
        FindObjectOfType<playTutorialVideo>().clip.SetActive(true);
        StartCoroutine(playTutorialVideo.WaitForFunction());
    }

    public void PlayVid2()
    {
        FindObjectOfType<playTutorialVideo>().canvas.gameObject.SetActive(false);
        FindObjectOfType<playTutorialVideo>().clip1.SetActive(true);
        StartCoroutine(playTutorialVideo.WaitForFunction());
    }

    public void PlayVid3()
    {
        FindObjectOfType<playTutorialVideo>().canvas.gameObject.SetActive(false);
        FindObjectOfType<playTutorialVideo>().clip2.SetActive(true);
        StartCoroutine(playTutorialVideo.WaitForFunction());
    }
}
