using RockTools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rockController : MonoBehaviour
{
    public GameObject cube; // The cube being dragged
    public GameObject rockGenerator; // Reference to the rock generator script

    private float lastCubeYPosition;

    public RockGenerator RG;
    public float stepsize = 1.0f;
    public float last_check = -1.0f;

    private float y_initial;


    private void Start()
    {
        y_initial = cube.transform.position.y;
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //     RG.pDensity +=1;
        //}
        float yPos = cube.transform.position.y + 5f;
        print(yPos);

        // Adjust RockGenerator variables based on Y position
        RG.pDensity = (int)Math.Round(yPos * 20f) + 30;
        RG.pRadius = yPos * 0.6f;
        //RG.pWideness = Mathf.Clamp(yPos * 0.15f, 0.1f, 1f);
        RG.pDecentralize = 2f - yPos * 0.3f;
        RG.pScaleLocal = yPos * 0.6f;
        RG.pFlatness = yPos * 0.2f;
        //RG.pTallness = Mathf.Clamp(yPos * 0.2f, 0.1f, 1f);

        //if (yPos > stepsize+y_initial)
        //{
        //    RG.pWave = UnityEngine.Random.Range(0.1f, 1f);
        //    last_check = (float)(Math.Floor(yPos / stepsize) * stepsize);
        //}

        //RG.pWave = UnityEngine.Random.Range(0.1f, 1f);
        //RG.pAsymmetry = Random.Range(-1f, 1f);

    }
}
