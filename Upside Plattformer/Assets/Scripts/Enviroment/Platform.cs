using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.transform.parent.gameObject,8);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector2.up * speed;
    }
}
