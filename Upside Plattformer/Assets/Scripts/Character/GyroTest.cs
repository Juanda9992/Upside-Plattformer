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
    private Vector3 firstPosition;

    public UnityEvent onScoreIncreased;
    public delegate void onScore();
    public delegate void onGoalReached();

    public static event onGoalReached onReachedGoal;
    public static event onScore onScored;

    [HideInInspector]
    public bool collision = false;
    public float pointsInARow = 0;
    [HideInInspector]
    public int maxScore;

    [SerializeField]
    private GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");
        firstPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //The formula for the player movement
        currentSpeed = Input.acceleration.x * sensitivity;
    }

    void FixedUpdate()
    {
        //Actually applies the force depending the device rotation
        rb.AddForce(new Vector2(currentSpeed,0));
            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Points"))
        {

            IncreaseScore();
            Sound_Manager.PlaySound("point");
            Instantiate(particle,transform.position,Quaternion.identity);

            
            onScoreIncreased?.Invoke();
            onScored?.Invoke();
        }
    }

    private void ResetStats()
    {
        transform.position = firstPosition;
        score = 0;
    }

    private void IncreaseScore()
    {
        pointsInARow ++;
        score+= Mathf.FloorToInt(pointsInARow);

        if(score % 50 == 0)
        {
            onReachedGoal?.Invoke();
        }
        if(maxScore < score)
        {
            maxScore = score;
            PlayerPrefs.SetInt("MaxScore",maxScore);
        }
    }

    void OnEnable()
    {
        Scene_Loader.onRestarted+= ResetStats;
    }
    void OnDisable()
    {
        Scene_Loader.onRestarted-= ResetStats;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collision = true;
        pointsInARow = 0;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        collision = false;
    }
}
