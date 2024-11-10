using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MoveManager : MonoBehaviour
{
    private SpriteCycler spriteCycler;
    private MouseDraw mouseDraw;
    private ballCheck ballCheck;

    public GameObject spriteM;
    public GameObject lineM;
    public GameObject ballM;

    private bool isMismatch = false;
    private bool circleMove = false;
    private bool lineDrawn = false;

    public GameObject button;

    private void Start()
    {
        button.SetActive(false);
    }
    private void Update()
    {
        spriteCycler = spriteM.GetComponent<SpriteCycler>();
        isMismatch = spriteCycler.isMismatch;
        //print("1"+isMismatch);

        ballCheck = ballM.GetComponent<ballCheck>();
        circleMove = ballCheck.anyCircleMoved;
        //print("2" + circleMove);

        mouseDraw = lineM.GetComponent<MouseDraw>();
        lineDrawn = mouseDraw.checkDraw;
        //print("3" + lineDrawn);

        if (isMismatch && circleMove && lineDrawn)
        {
            print("yes");
            button.SetActive(true);
        }
    }

}
