using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Y_LeftUI : MonoBehaviour
{

    [SerializeField] public Slider selectorUI;
    //[SerializeField] Scrollbar selectorUI;
    [SerializeField] public GameObject[] curTiles= new GameObject[4];
    public static GameObject curTile;
    public static int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CurTileSwap()
    {
        switch (selectorUI.value)
        {
            case 1:
                Manager.Throwable = curTiles[0];
                id = 1;
                break;
            case 2:
                Manager.Throwable = curTiles[1];
                id = 2;
                break;
            case 3:
                Manager.Throwable = curTiles[2];
                id = 3;
                break;
            case 4:
                Manager.Throwable = curTiles[3];
                id = 4;
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            selectorUI.value -= 1;
            CurTileSwap();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            selectorUI.value += 1;
            CurTileSwap();
        }
        
    }
}
