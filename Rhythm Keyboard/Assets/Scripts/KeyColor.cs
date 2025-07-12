using UnityEngine;

public class KeyColor : MonoBehaviour
{



    [SerializeField] private Color normalColor = new Color(1f, 1f, 1f, 1f);
    [SerializeField] private Color pressedColor = new Color(0.6f, 0.6f, 0.6f, 1f);
    [SerializeField] private Color tapColor = new Color(0f, 0.5f, 1f, 1f);
    [SerializeField] private Color holdColor = new Color(1f, 0.2f, 0f, 1f);
    [SerializeField] private float fadeDuration = 0.5f;
    private Color startColor;
    private Color targetColor;
    private float elapsedTime = 0f;

    public void SetColor(string type)
    {
        Color targetColor = normalColor;

        switch (type)
        {
            case "normal":
                targetColor = normalColor;
                break;
            case "pressed":
                targetColor = pressedColor;
                break;
            case "tap":
                targetColor = tapColor;
                break;
            case "hold":
                targetColor = holdColor;
                break;
        }
        Color currentColor = GetComponent<SpriteRenderer>().color;
        FadeColor(currentColor, targetColor, fadeDuration);
    }

    public void FadeColor(Color startColor, Color targetColor, float duration)
    {
        this.startColor = startColor;
        this.targetColor = targetColor;
        this.elapsedTime = 0f;
    }

    void Update()
    {
        if (startColor != targetColor)
        {
            elapsedTime += Time.deltaTime;
            float lerpFactor = Mathf.Clamp01(elapsedTime / fadeDuration);
            Color newColor = Color.Lerp(startColor, targetColor, lerpFactor);
            GetComponent<SpriteRenderer>().color = newColor;

            if (elapsedTime >= fadeDuration)
            {
                startColor = targetColor; // Update start color to the target color
            }
        }
    }



}
