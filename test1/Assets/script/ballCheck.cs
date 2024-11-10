using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCheck : MonoBehaviour
{
    public List<DragCircle> dragCircles; // Assign your DragCircle objects in the inspector
    public bool anyCircleMoved = false; // This will track if any circle has moved

    private void Update()
    {
        // Check if any circle has moved
        anyCircleMoved = CheckIfAnyCircleMoved();

        // You can add further operations here based on anyCircleMoved
        if (anyCircleMoved)
        {
            // Perform your operations
            //Debug.Log("At least one circle has moved!");
        }
    }

    private bool CheckIfAnyCircleMoved()
    {
        foreach (DragCircle circle in dragCircles)
        {
            if (circle.hasMoved)
            {
                return true; // Return true if any circle has moved
            }
        }
        return false; // Return false if none have moved
    }
}
