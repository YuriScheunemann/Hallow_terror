using UnityEngine;

public class AutoCreditsScroll : MonoBehaviour
{
    public RectTransform credits;
    public float autoScrollSpeed = 50f;
    public float scrollBoost = 200f;

    float minY;
    float maxY;

    void Start()
    {
        RectTransform panel = credits.parent.GetComponent<RectTransform>();
        float contentHeight = credits.rect.height;
        float panelHeight = panel.rect.height;

        maxY = 0f;
        minY = panelHeight - contentHeight;

        credits.anchoredPosition = new Vector2(0, minY);
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
