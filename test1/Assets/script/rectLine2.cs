using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rectLine2 : MonoBehaviour
{
    public List<GameObject> cubes;
    public GameObject c0;
    public LineRenderer lineRenderer1;
    public LineRenderer lineRenderer2;
    public LineRenderer lineRenderer3;
    public LineRenderer lineRenderer4;
    public LineRenderer lineRenderer5;
    public LineRenderer lineRenderer6;        
    public LineRenderer lineRenderer7;        
    public LineRenderer lineRenderer8;
    public LineRenderer lineRenderer9;
    public LineRenderer lineRenderer10;
    public LineRenderer lineRenderer11;
    public LineRenderer lineRenderer12;

    private void Start()
    {
        SetAlpha(lineRenderer1,0);
        SetAlpha(lineRenderer2, 0);
        SetAlpha(lineRenderer3, 0);
        SetAlpha(lineRenderer4, 0);
        SetAlpha(lineRenderer5, 0);
        SetAlpha(lineRenderer6, 0);
        SetAlpha(lineRenderer7, 0);
        SetAlpha(lineRenderer8, 0);
        SetAlpha(lineRenderer9, 0);
        SetAlpha(lineRenderer10, 0);
        SetAlpha(lineRenderer11, 0);
        SetAlpha(lineRenderer12, 0);
    }

    void Update()
    {
        UpdateLineRendererPositions();
    }

    void UpdateLineRendererPositions()
    {
    //1, 2
    lineRenderer1.SetPosition(0, cubes[0].transform.position);
    lineRenderer1.SetPosition(1, cubes[1].transform.position);
    SetAlpha(lineRenderer1,0.7f);

    //1, 3
    lineRenderer2.SetPosition(0, cubes[0].transform.position);
    lineRenderer2.SetPosition(1, cubes[2].transform.position);
    SetAlpha(lineRenderer2, 0.7f);

    //1, 5
    lineRenderer3.SetPosition(0, cubes[0].transform.position);
    lineRenderer3.SetPosition(1, cubes[4].transform.position);
    SetAlpha(lineRenderer3, 0.7f);

    //2, 4
    lineRenderer4.SetPosition(0, cubes[1].transform.position);
    lineRenderer4.SetPosition(1, cubes[3].transform.position);
    SetAlpha(lineRenderer4, 0.7f);

    //2, 6
    lineRenderer5.SetPosition(0, cubes[1].transform.position);
    lineRenderer5.SetPosition(1, cubes[5].transform.position);
    SetAlpha(lineRenderer5, 0.7f);

    //3, 4
    lineRenderer6.SetPosition(0, cubes[2].transform.position);
    lineRenderer6.SetPosition(1, cubes[3].transform.position);
    SetAlpha(lineRenderer6, 0.7f);

    //3, 7
    lineRenderer7.SetPosition(0, cubes[2].transform.position);
    lineRenderer7.SetPosition(1, cubes[6].transform.position);
    SetAlpha(lineRenderer7, 0.7f);

    //4, 8
    lineRenderer8.SetPosition(0, cubes[3].transform.position);
    lineRenderer8.SetPosition(1, cubes[7].transform.position);
    SetAlpha(lineRenderer8, 0.7f);

    //5, 6
    lineRenderer9.SetPosition(0, cubes[4].transform.position);
    lineRenderer9.SetPosition(1, cubes[5].transform.position);
    SetAlpha(lineRenderer9, 0.7f);

    //5, 7
    lineRenderer10.SetPosition(0, cubes[4].transform.position);
    lineRenderer10.SetPosition(1, cubes[6].transform.position);
    SetAlpha(lineRenderer10, 0.7f);

    //6, 8
    lineRenderer11.SetPosition(0, cubes[5].transform.position);
    lineRenderer11.SetPosition(1, cubes[7].transform.position);
    SetAlpha(lineRenderer11, 0.7f);

    //7, 8
    lineRenderer12.SetPosition(0, cubes[6].transform.position);
    lineRenderer12.SetPosition(1, cubes[7].transform.position);
    SetAlpha(lineRenderer12, 0.7f);

    }

    private void SetAlpha(LineRenderer lr, float alpha)
    {
        Color color = lr.startColor;
        color.a = alpha;
        lr.startColor = color;
        lr.endColor = color;
    }
}
