using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class check : MonoBehaviour
{
    // Start is called before the first frame update
    public bool notthird;
    public GameObject oppiz_check;
    public bool right;
    private GameObject onme;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onme.gameObject.tag== oppiz_check.gameObject.GetComponent<check>().onme.tag && notthird)
        {
            right = true;
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        onme = other.gameObject;

        if(other.tag == "sound3" && !notthird)
        {
            right = true ;
            //Debug.Log("2");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("mmmm");
        onme = null;
        if (other.tag == "sound1"|| other.tag == "sound2" || other.tag == "sound3")
        {
            right = false;
            Debug.Log("3");
        }
    }
}
