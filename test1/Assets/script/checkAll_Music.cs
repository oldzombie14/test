using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAll : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject[] boxes;
    public GameObject[] balls;
    public GameObject[] detect;
    public GameObject plane1;
    public GameObject triggerPlane;
    //public bool allright;
    public bool allright2;
    public GameObject diag2;
    public GameObject diag3;

    private HashSet<GameObject> hasPlayedAudio = new HashSet<GameObject>();
    //int x=0;

    private void Start()
    {

    }

    void Update()
    {
        //for(int i = 0; i<cubes.Length;i++)
        //{
        //    if (cubes[i].gameObject.GetComponent<check>().right)
        //    {
        //        x++;
        //    }
        //    else
        //    {
        //x = 0;
        //        break;
        //    }
        //}
        //if(x==5)
        //{
        //    allright = true;
        //    print("hi");
        //}

        bool allright2 = cubes[0].GetComponent<check>().right &&
                        cubes[1].GetComponent<check>().right &&
                        cubes[2].GetComponent<check>().right &&
                        cubes[3].GetComponent<check>().right &&
                        cubes[4].GetComponent<check>().right;
        print(allright2);

        if (allright2 == true)
        {
            //print("ya");
            triggerPlane.SetActive(true);
            diag2.SetActive(false);
            diag3.SetActive(true);
            StartCoroutine(DelayedAction2());
        }
    }
    IEnumerator DelayedAction2()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            //print(i);
            boxes[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.8f);
        }
    }
}
