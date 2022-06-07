using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer[] sRenderer;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponentsInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        UpdateColor();
        Destroy(gameObject,8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }

    public void UpdateColor()
    {
        foreach(var render in sRenderer)
        {
            render.DOColor(Color_Manager.manager.nextColor,0.7f).SetEase(Ease.OutQuart);
        }
    }

    void OnEnable()
    {
        GyroTest.onScored += UpdateColor;
    }
    void OnDisable()
    {
        GyroTest.onScored -= UpdateColor;
    }
}
