using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkAll_Aesthetics : MonoBehaviour
{
    public GameObject[] poles;
    public GameObject[] others;
    //public bool allright;
    public bool allright2;
    public string fsmName = "YourFSMName";
    public string eventName = "VariableTrueEvent";
    //int x=0;

    void Update()
    {

        bool allright2 = poles[0].GetComponent<testDragDropSlot>().ifmatch &&
                        poles[1].GetComponent<testDragDropSlot>().ifmatch &&
                        poles[2].GetComponent<testDragDropSlot>().ifmatch &&
                        poles[3].GetComponent<testDragDropSlot>().ifmatch &&
                        poles[4].GetComponent<testDragDropSlot>().ifmatch &&
                        poles[5].GetComponent<testDragDropSlot>().ifmatch &&
                        others[0].GetComponent<testDragDropSlot>().ifmatch &&
                        others[1].GetComponent<testDragDropSlot>().ifmatch &&
                        others[2].GetComponent<testDragDropSlot>().ifmatch;
        //print(allright2);

        if (allright2 == true)
        {
            PlayMakerFSM fsm = GetComponent<PlayMakerFSM>();

            if (fsm != null)
            {
                fsm.SendEvent(eventName);
            }
        }
    }
}
