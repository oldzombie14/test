using DG.Tweening.Core.Easing;
using UnityEngine;

public class Card : MonoBehaviour
{
    public SpriteRenderer frontRenderer;
    public SpriteRenderer backRenderer;

    private bool isFlipped = false;

    public delegate void CardClicked(int cardIndex);
    public event CardClicked OnCardClicked;

    private void Start()
    {
        frontRenderer.sprite = null;
        backRenderer.sprite = null;
        backRenderer.gameObject.SetActive(true);
        frontRenderer.gameObject.SetActive(false);
    }

    public void SetCard(Sprite front, Sprite back)
    {
        frontRenderer.sprite = front;
        backRenderer.sprite = back;
    }

    private void OnMouseDown()
    {
        if (OnCardClicked != null)
        {
            OnCardClicked(GetInstanceID()); // Or pass other identifying information
        }
    }

    public void FlipCard()
    {
        isFlipped = !isFlipped;
        frontRenderer.gameObject.SetActive(isFlipped);
        backRenderer.gameObject.SetActive(!isFlipped);
    }
}
