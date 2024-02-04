using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Y_LeftUI : MonoBehaviour
{
    [SerializeField] Slider selectorUI;
    //[SerializeField] Scrollbar selectorUI;
    [SerializeField] GameObject[] curTiles= new GameObject[4];
    public GameObject curTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            selectorUI.value -= 1;
        }
        if (Input.GetButtonUp("Fire3"))
        {
            selectorUI.value += 1;
        }
        switch (selectorUI.value)
        {
            case 1:
                curTile = curTiles[0];
                break;
            case 2:
                curTile = curTiles[1];
                break;
            case 3:
                curTile = curTiles[2];
                break;
            case 4:
                curTile = curTiles[3];
                break;
        }
    }
}
