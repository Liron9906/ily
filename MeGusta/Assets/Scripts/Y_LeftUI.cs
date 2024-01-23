using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Y_LeftUI : MonoBehaviour
{
    [SerializeField] Scrollbar selectorUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2") && 0 < selectorUI.value)
        {
            selectorUI.value = (selectorUI.value - 0.25f);
        }
        if (Input.GetButtonUp("Fire3") && selectorUI.value < 1)
        {
            selectorUI.value += 0.25f;
        }
    }
}
