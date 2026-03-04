using UnityEngine;

public class Player_Color : MonoBehaviour
{

    private SpriteRenderer playerRenderer;
    void Awake()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        playerRenderer.color = color;
    }
}
