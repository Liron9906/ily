using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTutorialVideo : MonoBehaviour
{
    [SerializeField] public GameObject clip;
    [SerializeField] public GameObject clip1;
    [SerializeField] public GameObject clip2;
    [SerializeField] public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        clip.SetActive(false);
        clip1.SetActive(false);
        clip2.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static IEnumerator WaitForFunction()
    {

        yield return new WaitForSeconds(10f);
        FindObjectOfType<playTutorialVideo>().canvas.gameObject.SetActive(true);
        FindObjectOfType<playTutorialVideo>().clip.SetActive(false);
        FindObjectOfType<playTutorialVideo>().clip1.SetActive(false);
        FindObjectOfType<playTutorialVideo>().clip2.SetActive(false);

    }
}
