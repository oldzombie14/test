using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleCardScript : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject theTar;
    //private GameObject theTar;
    public GameManager gameManager;

    List<GameObject> allChild = new List<GameObject>();
    List<GameObject> TarChild = new List<GameObject>();
    void Start()
    {
        GameObject theTar = gameManager.GetCurrentTar();
        

        //Debug.Log($"now: {theTar.name}");

        foreach (Transform child in this.transform)
        {
            GameObject childGameObject = child.gameObject;
            allChild.Add(childGameObject);

        }

        foreach (Transform child in theTar.transform)
        {

            GameObject childGameObject = child.gameObject;
            TarChild.Add(childGameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 0; i < allChild.Count; i++)
            {
                allChild[i].GetComponent<SpriteRenderer>().sprite = TarChild[i].GetComponent<SpriteRenderer>().sprite;
            }


        }
    }
}
