using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skillCheck : MonoBehaviour
{
    public bool stopSpin = false;
    bool endSC;
    public string saveStat = "default1";
    public bool didHit;
    [SerializeField] GameObject taskCanvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            endSC = true;
            stopSpin = true;
            if (saveStat=="good")
            {
                didHit = true;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            else if (saveStat=="bad")
            {
                didHit = true;
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            Destroy(taskCanvas, 2);
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
