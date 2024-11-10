using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipping : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject theTar;
    //private GameObject theTar;
    //public GameManager manager;

    private SpriteRenderer rend;

    //[SerializeField]
    private GameObject backSpriteObject, faceSpriteObject;
    private Sprite faceSprite, backSprite;
    private bool coroutineAllowed, facedUp;
    public GameManager manager;

    List<GameObject> allChild = new List<GameObject>();
    List<GameObject> TarChild = new List<GameObject>();

    void Start()
    {
        //rend.sprite = backSprite;
        coroutineAllowed = true;
        facedUp = false;
    } 

    public void flip()
    {
        GameObject currentTar = manager.GetCurrentTar();

        foreach (Transform child in this.transform)
        {
            GameObject childGameObject = child.gameObject;
            allChild.Add(childGameObject);

        }

        foreach (Transform child in currentTar.transform)
        {

            GameObject childGameObject = child.gameObject;
            TarChild.Add(childGameObject);
        }

        for (int i = 0; i < allChild.Count; i++)
        {
            allChild[i].GetComponent<SpriteRenderer>().sprite = TarChild[i].GetComponent<SpriteRenderer>().sprite;
        }

        faceSpriteObject = allChild[0].gameObject;
        backSpriteObject = allChild[1].gameObject;

        if (faceSpriteObject != null)
        {
            faceSprite = faceSpriteObject.GetComponent<SpriteRenderer>().sprite;
            faceSpriteObject.SetActive(false);
        }
        else { print("face not found"); }

        if (backSpriteObject != null)
        {
            backSprite = backSpriteObject.GetComponent<SpriteRenderer>().sprite;
            backSpriteObject.SetActive(true);
        }
        else { print("back not found"); }

        StartCoroutine(RotateCard());

    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        
        if (facedUp == false)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                backSpriteObject.transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.02f);
                if (i >= 173f)
                {
                    //yield return new WaitForSeconds(0.02f);
                    backSpriteObject.SetActive(false);
                    
                    faceSpriteObject.SetActive(true);
                    //rend.sprite = faceSprite;
                    //Debug.Log($"rend sprite: {rend.sprite.name}");
                }
            }
        }
       

        //rend.sprite = facedUp ? backSprite : null;

        coroutineAllowed = true;
        facedUp = !facedUp;
    }
}

