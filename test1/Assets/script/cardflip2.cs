using DG.Tweening.Core.Easing;
using System.Collections;
using UnityEngine;

public class cardflip2 : MonoBehaviour
{
    private SpriteRenderer rend;

    [SerializeField]
    private GameObject faceSpriteObject, backSpriteObject;

    private Sprite faceSprite, backSprite;
    private bool coroutineAllowed, facedUp;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        GameObject theTar = manager.GetCurrentTar();

        Transform parentTransform = theTar.transform;
        Debug.Log($"theTar: {theTar.name}");
        Transform ChildTransform = parentTransform.GetChild(0);
        GameObject target = ChildTransform.gameObject;
        faceSpriteObject = target.gameObject;
        Debug.Log($"sprite: {faceSpriteObject.name}");
        faceSprite = faceSpriteObject.GetComponent<SpriteRenderer>().sprite;


        // Set initial sprites
        if (backSpriteObject != null)
        {
            backSprite = backSpriteObject.GetComponent<SpriteRenderer>().sprite;
        }

        // Initial states
        if (faceSpriteObject != null)
        {
            faceSpriteObject.SetActive(false);
        }
        else
        {
            print("no");
        }

        if (backSpriteObject != null)
        {
            backSpriteObject.SetActive(true);
        }

        rend.sprite = backSprite;
        coroutineAllowed = true;
        facedUp = false;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            manager.OnCardFlip();
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        GameObject theTar = manager.GetCurrentTar();

        Transform parentTransform = theTar.transform;
        //Debug.Log($"theTar: {theTar.name}");

        Transform ChildTransform = parentTransform.GetChild(0);
        GameObject target = ChildTransform.gameObject;
        faceSpriteObject = target.gameObject;
        faceSprite = faceSpriteObject.GetComponent<SpriteRenderer>().sprite;
        //Debug.Log($"sprite obj: {faceSpriteObject.name}");
        Debug.Log($"sprite: {faceSprite.name}");

        if (!facedUp)
        {
            // Show face sprites and hide back sprite during the flip
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.02f);
                if (i >= 180f)
                {
                    yield return new WaitForSeconds(0.02f);
                    backSpriteObject.SetActive(false);
                    if (faceSpriteObject != null)
                    {
                        print("not null");
                    }
                    faceSpriteObject.SetActive(true);
                    rend.sprite = faceSprite;
                    //Debug.Log($"rend sprite: {rend.sprite.name}");
                }
            }
        }
        else
        {
            // Show back sprite and hide face sprites during the flip
            if (faceSpriteObject != null)
            {
                faceSpriteObject.SetActive(false);
            }

            if (backSpriteObject != null)
            {
                backSpriteObject.SetActive(true);
            }

            for (float i = 180f; i >= 0f; i -= 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                yield return new WaitForSeconds(0.01f);
            }
        }

        // Final state
        //rend.sprite = facedUp ? backSprite : null;

        coroutineAllowed = true;
        facedUp = !facedUp;
    }
}
