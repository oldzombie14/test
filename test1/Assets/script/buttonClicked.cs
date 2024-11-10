using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClicked : MonoBehaviour
{
    public GameObject bag;
    public GameObject face;
    public GameObject cat;
    public GameObject catEmoji;

    public GameObject dialog;
    public GameObject bagDialog;
    public GameObject faceDialog;
    public GameObject faceDialog2;
    public GameObject catDialog;

    public GameObject leftEaring;
    public GameObject rightEaring;

    public GameObject panel;
    public GameObject circle;
    public GameObject box;
    public GameObject balls;

    public Vector3 leftEaringTarget;
    public Vector3 rightEaringTarget;

    public Button yourButton; // Assign the button from the inspector

    public MouseDraw mouseDraw;

    private Image buttonImage;

    public Sprite[] newSprites;


    void Start()
    {
        // Add the OnButtonClick method to the button's click event
        yourButton.onClick.AddListener(OnButtonClick);
        MouseDraw mouseDraw = GetComponent<MouseDraw>();
        buttonImage = yourButton.GetComponent<Image>();

    }

    void OnButtonClick()
    {
        buttonImage.enabled = false;
        ChangeChildSprites();
        // Start the coroutine when the button is clicked
        StartCoroutine(ShowBagAndFace());
        //yourButton.SetActive(false);
    }

    private void ChangeChildSprites()
    {
        // Get all child objects of the balls GameObject
        Transform[] children = balls.GetComponentsInChildren<Transform>();

        for (int i = 1; i < children.Length; i++) // Start from 1 to skip the parent itself
        {
            SpriteRenderer spriteRenderer = children[i].GetComponent<SpriteRenderer>();
            if (spriteRenderer != null && i - 1 < newSprites.Length) // Check if there is a new sprite
            {
                spriteRenderer.sprite = newSprites[i - 1]; // Change sprite
            }
        }
    }

    private IEnumerator ShowBagAndFace()
    {
        // Show the bag and its dialogue
        panel.SetActive(false);
        circle.SetActive(false);
        box.SetActive(false);
        

        face.SetActive(false);
        cat.SetActive(false);
        catEmoji.SetActive(false);
        faceDialog.SetActive(false);
        faceDialog2.SetActive(false);
        catDialog.SetActive(false);
        mouseDraw.DeactivateAllLines();
        leftEaring.SetActive(false);
        rightEaring.SetActive(false);
        dialog.SetActive(false);


        bag.SetActive(true);
        bagDialog.SetActive(true);

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide the bag and show the face and its dialogues
        bag.SetActive(false);
        bagDialog.SetActive(false);
        balls.SetActive(false);
        face.SetActive(true);
        faceDialog.SetActive(true);
        faceDialog2.SetActive(true);
        leftEaring.SetActive(true);
        rightEaring.SetActive(true);

        // Move earrings to target positions
        StartCoroutine(MoveEarrings());

        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Hide face and earrings, show cat and its emoji and dialogue
        face.SetActive(false);
        faceDialog.SetActive(false);
        faceDialog2.SetActive(false);
        leftEaring.SetActive(false);
        rightEaring.SetActive(false);
        mouseDraw.ActivateAllLines();
        cat.SetActive(true);
        catEmoji.SetActive(true);
        catDialog.SetActive(true);
    }

    private IEnumerator MoveEarrings()
    {
        float duration = 1.0f; // Duration of the movement
        float elapsedTime = 0f;

        // Store the starting positions of the earrings
        Vector3 leftEaringStart = leftEaring.transform.position;
        Vector3 rightEaringStart = rightEaring.transform.position;

        // Smoothly move the earrings to their target positions
        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            leftEaring.transform.position = Vector3.Lerp(leftEaringStart, leftEaringTarget, t);
            rightEaring.transform.position = Vector3.Lerp(rightEaringStart, rightEaringTarget, t);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait for the next frame
        }

        // Ensure the earrings are exactly at the target position
        leftEaring.transform.position = leftEaringTarget;
        rightEaring.transform.position = rightEaringTarget;
    }
}
