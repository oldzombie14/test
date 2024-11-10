using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class compress : MonoBehaviour
{
    // Start is called before the first frame update
    public bool yfinish;
    public bool xfinish;
    public bool yfinished;
    Tweener scaly;
    Tweener scalx;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scal = this.transform.localScale;
        if(Input.GetMouseButtonDown(0) && scal.y > 0.2f)
        {
            scaly = this.transform.DOScaleY(0.1f, 3f);
        }
        else if (Input.GetMouseButtonUp(0) && !yfinish)
        {
            scaly.Kill();
            this.transform.DOScaleY(4f,0.5f);
        }
        if(scal.y < 0.2f)
        {
            yfinish = true;
        }

        if (Input.GetMouseButtonDown(0) && scal.x > 0.2f && yfinish)
        {
            scalx = this.transform.DOScaleX(0.1f, 3f);
        }
        else if (Input.GetMouseButtonUp(0) && !xfinish)
        {
            scalx.Kill();
            this.transform.DOScaleX(4f, 0.5f);
        }
        if (scal.x < 0.2f)
        {
            xfinish = true;
        }

        if (yfinish&&xfinish&&Input.GetMouseButtonDown(0))
        {
            this.transform.DOScaleY(4f, 3f);
            yfinished = true;
            yfinish = false;
        }
        else if(yfinished && Input.GetMouseButtonDown(0))
        {
            this.transform.DOScaleX(4f, 3f);
        }
    }
}
