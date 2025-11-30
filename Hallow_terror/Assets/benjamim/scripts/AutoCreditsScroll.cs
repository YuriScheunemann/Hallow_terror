using UnityEngine;

public class AutoCreditsScroll : MonoBehaviour
{
    public RectTransform credits;
    public float autoScrollSpeed = 50f;
    public float scrollBoost = 100f;

    private float minY;
    private float maxY;

    void Start()
    {
        RectTransform panel = credits.parent.GetComponent<RectTransform>();

        maxY = 0f;
        minY = Mathf.Min(panel.rect.height - credits.rect.height, 0f);

        Vector2 startPos = credits.anchoredPosition;
        startPos.y = minY;
        credits.anchoredPosition = startPos;
    }

    void Update()
    {
        float speed = autoScrollSpeed;
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");

        if (scrollInput > 0f)
            speed += scrollInput * scrollBoost;

        float newY = credits.anchoredPosition.y + speed * Time.deltaTime;
        newY = Mathf.Clamp(newY, minY, maxY);

        credits.anchoredPosition = new Vector2(credits.anchoredPosition.x, newY);
    }
}
