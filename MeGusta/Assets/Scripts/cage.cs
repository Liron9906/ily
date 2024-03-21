using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cage : MonoBehaviour
{
    [SerializeField] GameObject skillCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject SkillCHECK =
            Instantiate(skillCheck, new Vector3(-8, -1, 10), Quaternion.identity) as GameObject;
            SkillCHECK.SetActive(true);
        }
    }
}
