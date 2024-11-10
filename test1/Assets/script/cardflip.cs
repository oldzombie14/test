using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;

public class cardflip : MonoBehaviour
{

    public GameManager manager;
    public flipping flipping;
    private int clicked = 0;


    void Start()
    {

    }

    private void OnMouseDown()
    {      
        if (clicked < 1)
        {
            manager.OnCardFlip();
            flipping.flip();
            clicked++;
        }
    }
}
