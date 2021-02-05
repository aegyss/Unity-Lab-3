using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirteenBallBehaviour : MonoBehaviour
{
    public float XSpeed;
    public float XRotation;
    public float YRotation;
    public float ZRotation = 1;
    public float DegreesPerSecond = 180;
    public int BallNumber;
    public float XPosition = 3 - Random.value * 15;
    public float YPosition = 3 - Random.value * 15;
    public float ZPosition = 0;

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
        GameController gameController = Camera.main.GetComponent<GameController>();
        if (gameController.isGameRunning)
        {
            Vector3 axis = new Vector3(XRotation, YRotation, ZRotation);
            transform.RotateAround(Vector3.zero, axis, DegreesPerSecond * Time.deltaTime);
            transform.Translate(Time.deltaTime * XSpeed, 0, 0);
        }
    }

    private void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (controller.isGameRunning)
        {
            controller.ClickedThirteenBall();
            Destroy(gameObject);
        }
    }

    void ResetBall()
    {
        XSpeed = .5F;
        YPosition = 3 - Random.value * 6;
        transform.position = new Vector3(XPosition, YPosition, ZPosition);
    }
}
