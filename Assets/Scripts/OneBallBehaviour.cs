using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBallBehaviour : MonoBehaviour
{
    public float XRotation = 0;
    public float YRotation = 1;
    public float ZRotation = 0;
    public float DegreesPerSecond = 180;
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = .7F;
    public int BallNumber = 0;
    public int TooFar = 6;
    


    private void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (controller.isGameRunning)
        {
            controller.ClickedOneBall();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        BallNumber = controller.BallCount;
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (controller.isGameRunning)
        {
            XSpeed += Multiplier - Random.value * Multiplier * 2;
            YSpeed += Multiplier - Random.value * Multiplier * 2;
            ZSpeed += Multiplier - Random.value * Multiplier * 2;
            transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);
            if (Mathf.Abs(transform.position.x) > TooFar || Mathf.Abs(transform.position.y) > TooFar || Mathf.Abs(transform.position.z) > TooFar)
            {
                ResetBall();
            }


            //Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
            //This rotates the ball.
            //transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
        }
        //transform.Rotate(axis, DegreesPerSecond * Time.deltaTime);
        //Debug.DrawRay(Vector3.zero, axis, Color.yellow, 5f);
    }

    void ResetBall()
    {
        XSpeed = Multiplier - Random.value * Multiplier * 2;
        YSpeed = Multiplier - Random.value * Multiplier * 2;
        ZSpeed = Multiplier - Random.value * Multiplier * 2;
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
    }
}
