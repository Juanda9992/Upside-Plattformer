using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlattformSpawner spawner;
    private SpriteRenderer[] sRenderer;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<PlattformSpawner>();
        sRenderer = GetComponentsInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        UpdateColor();
        Destroy(gameObject,8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speed = (2 +  (((spawner.timeBetweenSpawn * 2) /0.9f)-2));
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
        Scene_Loader.onRestarted += EraseExistingPlatforms;
        GyroTest.onScored += UpdateColor;
    }
    void OnDisable()
    {
        Scene_Loader.onRestarted -= EraseExistingPlatforms;
        GyroTest.onScored -= UpdateColor;
    }

    private void EraseExistingPlatforms()
    {
        Destroy(this.gameObject);
    }
}
