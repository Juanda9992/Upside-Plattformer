using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GyroTest : MonoBehaviour
{   
    public int score;
    [SerializeField]
    private float currentSpeed, sensitivity;
    private Rigidbody2D rb;

    public UnityEvent onScoreIncreased;
    public delegate void onScore();
    public static event onScore onScored;

    [SerializeField]
    private GameObject particle;
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Points"))
        {
            Instantiate(particle,transform.position,Quaternion.identity);
            score++;
            onScoreIncreased?.Invoke();
            onScored?.Invoke();
        }
    }
}
