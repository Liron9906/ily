using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class cage : MonoBehaviour
{
    [SerializeField] GameObject skillCheck1;
    [SerializeField] GameObject backGround;
    bool once= true;
    Color originalC;
    public static bool isOver = false;
    private void Awake()
    {
        originalC = backGround.GetComponent<SpriteRenderer>().color;
        originalC.a = 1;
        //StartCoroutine(fadeInAndOut(backGround, false, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForFunction(true));
    }
    // Update is called once per frame
    void Update()
    {
        if (!isOver)
        {
            if (skillCheck.colorTime == "HAPPY")
            {
                backGround.GetComponent<SpriteRenderer>().color = Color.green;
                skillCheck.colorTime = "";
                StartCoroutine(WaitForFunction(false));
            }
            else if (skillCheck.colorTime == "SAD")
            {
                backGround.GetComponent<SpriteRenderer>().color = Color.red;
                skillCheck.colorTime = "";
                StartCoroutine(WaitForFunction(false));
            }
            else
            {
                //this is the case where nothing is pressed :O
            }
        }
        else
        {
            //its joever
        }
        if (once && Manager.destroyThatBitch)
        {
            StartCoroutine(fadeInAndOut(backGround, false, 2));
            Destroy(backGround, 2.5f);
            once = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !isOver)
        {
            StartCoroutine(fadeInAndOut(backGround, true, 3));
            GameObject SkillCHECK =
            Instantiate(skillCheck1, new Vector3(0, 0, -9.9F), Quaternion.identity) as GameObject;
        }
    }
    IEnumerator WaitForFunction(bool test)
    {
        if (!test)
        {
            yield return new WaitForSeconds(0.5f);
            backGround.GetComponent<SpriteRenderer>().color = originalC;
        }
    }
    public static IEnumerator fadeInAndOut(GameObject objectToFade, bool fadeIn, float duration)
    {
        float counter = 0f;

        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0;
            b = 1;
        }
        else
        {
            a = 1;
            b = 0;
        }

        int mode = 0;
        Color currentColor = Color.clear;

        SpriteRenderer tempSPRenderer = objectToFade.GetComponent<SpriteRenderer>();
        Image tempImage = objectToFade.GetComponent<Image>();
        RawImage tempRawImage = objectToFade.GetComponent<RawImage>();
        MeshRenderer tempRenderer = objectToFade.GetComponent<MeshRenderer>();
        Text tempText = objectToFade.GetComponent<Text>();

        //Check if this is a Sprite
        if (tempSPRenderer != null)
        {
            currentColor = tempSPRenderer.color;
            mode = 0;
        }
        //Check if Image
        else if (tempImage != null)
        {
            currentColor = tempImage.color;
            mode = 1;
        }
        //Check if RawImage
        else if (tempRawImage != null)
        {
            currentColor = tempRawImage.color;
            mode = 2;
        }
        //Check if Text 
        else if (tempText != null)
        {
            currentColor = tempText.color;
            mode = 3;
        }

        //Check if 3D Object
        else if (tempRenderer != null)
        {
            currentColor = tempRenderer.material.color;
            mode = 4;

            //ENABLE FADE Mode on the material if not done already
            tempRenderer.material.SetFloat("_Mode", 2);
            tempRenderer.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            tempRenderer.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            tempRenderer.material.SetInt("_ZWrite", 0);
            tempRenderer.material.DisableKeyword("_ALPHATEST_ON");
            tempRenderer.material.EnableKeyword("_ALPHABLEND_ON");
            tempRenderer.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            tempRenderer.material.renderQueue = 3000;
        }
        else
        {
            yield break;
        }

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            switch (mode)
            {
                case 0:
                    tempSPRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 1:
                    tempImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 2:
                    tempRawImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 3:
                    tempText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
                case 4:
                    tempRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                    break;
            }
            yield return null;
        }
    }
}
