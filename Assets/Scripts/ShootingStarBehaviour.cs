using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarBehaviour : MonoBehaviour
{
    int ballNumber;
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 6F;
    public int TooFar = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameController gameController = Camera.main.GetComponent<GameController>();
        ballNumber = gameController.BallCount;
        ResetBall();

    }

    // Update is called once per frame
    void Update()
    {
        GameController gameController = Camera.main.GetComponent<GameController>();
        if (gameController.isGameRunning)
        {
            transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);
            if (Mathf.Abs(transform.position.x) > TooFar || Mathf.Abs(transform.position.x) > TooFar)
            {
                ResetBall();
            }
        }
    }

    void ResetBall()
    {
        XSpeed = Multiplier - Random.value * Multiplier * 5;
        YSpeed = Multiplier - Random.value * Multiplier * 5;
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 0);
    }

}
