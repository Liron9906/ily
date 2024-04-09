using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skillCheck : MonoBehaviour
{
    public bool stopSpin = false;
    //bool endSC;
    public string saveStat = "default1";
    public bool didHit= false;
    public static int countOfHits;
    public static string colorTime;
    [SerializeField] GameObject taskCanvas;
    [SerializeField] GameObject circle;
    [SerializeField] GameObject square;
    [SerializeField] GameObject empty;
    [SerializeField] GameObject big;
    [SerializeField] AudioClip good;
    [SerializeField] AudioClip bad;
    private void Awake()
    {
        StartCoroutine(cage.fadeInAndOut(circle, true, 2));
        StartCoroutine(cage.fadeInAndOut(square, true, 2));
        StartCoroutine(cage.fadeInAndOut(empty, true, 2));
        StartCoroutine(cage.fadeInAndOut(big, true, 2));
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //endSC = true;
            //stopSpin = true;
            if (saveStat == "good")
            {
                didHit = true;
                countOfHits++;
                colorTime = "HAPPY";
                AudioSource.PlayClipAtPoint(good, Camera.main.transform.position);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if (saveStat == "bad")
            {
                didHit = true;
                countOfHits = 0;
                colorTime = "SAD";
                AudioSource.PlayClipAtPoint(bad, Camera.main.transform.position);
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            //
        }
        if (Manager.destroyThatBitch)
        {
            StartCoroutine(cage.fadeInAndOut(circle, false, 2));
            StartCoroutine(cage.fadeInAndOut(square, false, 2));
            StartCoroutine(cage.fadeInAndOut(empty, false, 2));
            StartCoroutine(cage.fadeInAndOut(big, false, 2));
            Destroy(taskCanvas, 2.5f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "good")
            {
                saveStat = "good";
            }
            else if (other.tag == "bad")
            {
                saveStat = "bad";
            }
    }
}
