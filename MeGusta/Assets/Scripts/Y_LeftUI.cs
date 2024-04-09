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
    public static int id=1;
    public static bool isSquareUnlocked=true;
    public static bool isLshapeUnlocked=false;
    public static bool isSlimUnlocked=false;
    public static bool isPlusUnlocked=false;
    // Start is called before the first frame update
    void Start()
    {
       // Manager.Throwable = curTiles[0];
    }
    public void CurTileSwap()
    {
        Debug.Log($"id- {id}");
        switch (selectorUI.value)
        {
            case 1:
                if (isSquareUnlocked)//checking if unlocked by second player(moving guy script is changing the value)
                {
                    FindObjectOfType<Manager>().respawn(curTiles[0]);
					id = 1;
				}

                break;
            case 2:
                if (isPlusUnlocked)//checking if unlocked by second player(moving guy script is changing the value)
				{
					FindObjectOfType<Manager>().respawn(curTiles[1]);
					id = 2;
				}
                
                break;
            case 3:
                if (isLshapeUnlocked)//checking if unlocked by second player(moving guy script is changing the value)
				{
                    FindObjectOfType<Manager>().respawn(curTiles[2]);
					id = 3;
				}

                break;
            case 4:
                if (isSlimUnlocked)//checking if unlocked by second player(moving guy script is changing the value)
				{
                    
                    FindObjectOfType<Manager>().respawn(curTiles[3]);

					id = 4;
				}
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            selectorUI.value -= 1;
            CurTileSwap();
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            selectorUI.value += 1;
            CurTileSwap();
        }
        
    }
}
