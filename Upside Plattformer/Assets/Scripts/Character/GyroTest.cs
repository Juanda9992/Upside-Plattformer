using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GyroTest : MonoBehaviour
{   
    [SerializeField]
    private float currentSpeed, sensitivity;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(Screen.orientation);
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = Input.acceleration.x * sensitivity;
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(currentSpeed,0));    
    }
}
