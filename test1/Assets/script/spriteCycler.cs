using UnityEngine;

public class SpriteCycler : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public SpriteRenderer[] leftSprites;
    public SpriteRenderer[] rightSprites;

    private int leftIndex = 0;  // Tracks current index for left group
    private int rightIndex = 0; // Tracks current index for right group

    // Public boolean to check for pair mismatch
    public bool isMismatch = false;

    void Start()
    {
        // Initialize all sprites to be inactive except the first one in each group
        SetActiveSprite(leftSprites, leftIndex);
        SetActiveSprite(rightSprites, rightIndex);
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.CompareTag("LeftShape"))
                {
                    CycleSprites(leftSprites, ref leftIndex);
                }
                else if (hit.collider.gameObject.CompareTag("RightShape"))
                {
                    CycleSprites(rightSprites, ref rightIndex);
                }

                // Check for mismatch after cycling sprites
                CheckMismatch();
            }
        }
    }

    private void CycleSprites(SpriteRenderer[] sprites, ref int index)
    {
        // Deactivate the current sprite
        sprites[index].gameObject.SetActive(false);

        // Increment the index and wrap around if necessary
        index = (index + 1) % sprites.Length;

        // Activate the next sprite
        SetActiveSprite(sprites, index);
    }

    private void SetActiveSprite(SpriteRenderer[] sprites, int index)
    {
        // Check to prevent IndexOutOfRange exception
        if (index < sprites.Length && index >= 0)
        {
            sprites[index].gameObject.SetActive(true);
        }
    }

    private void CheckMismatch()
    {
        // Reset mismatch to false
        isMismatch = false;

        // Check if current left and right sprites are the same
        if (leftSprites.Length > 0 && rightSprites.Length > 0)
        {
            // Compare sprite references directly or their names
            if (leftSprites[leftIndex].sprite != rightSprites[rightIndex].sprite)
            {
                isMismatch = true; // Set to true if they do not match
            }
        }
    }
}
