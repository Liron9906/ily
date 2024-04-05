using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject[] lShapeRotations= new GameObject[4];
    [SerializeField] GameObject[] slimRotations= new GameObject[4];
    int count = 0;
    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("NEGAWHAT");


            count++;
            if (count >3)
            {
                count = 0;
            }
            if (count<0)
            {
                count = 3;
            }
            // Manager.Throwable = rotations[count];
            BetterRotation();
            Debug.Log(count);

        }
    }
    private void BetterRotation()
    {
        if (!FindObjectOfType<Shape>().IsLeftPressed)
        {
          //  Destroy(Manager.Throwable);
            switch (Y_LeftUI.id-1)
            {
                case 0:
                    FindObjectOfType<Manager>().respawn(slimRotations[count]);
                    Debug.Log("I got here!");
                    break;
                case 1:
                    FindObjectOfType<Manager>().respawn(lShapeRotations[count]);


					break;
                case 2:
                    break;
                case 3:

                    break;
                default:
					temp = Instantiate(slimRotations[count], Manager.throwableSpawnPoint, Quaternion.identity) as GameObject;
					Manager.Throwable = temp;
					break;
            }
        }
    }
}
