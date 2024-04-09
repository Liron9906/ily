using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempScript : MonoBehaviour
{
    [SerializeField] AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource.PlayClipAtPoint(buttonSound, Camera.main.transform.position);    
        }
    }
}
