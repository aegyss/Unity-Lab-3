using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EightBallBehaviour : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    public float ZSpeed;
    public float Multiplier = 3F;
    public int TooFar = 5;
    private void OnMouseDown()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (controller.isGameRunning)
        {
            controller.ClickedEightBall();
            controller.isEightBallOut = false;
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        GameController controller = Camera.main.GetComponent<GameController>();
        if (controller.isGameRunning)
        {
            transform.Translate(Time.deltaTime * XSpeed, Time.deltaTime * YSpeed, Time.deltaTime * ZSpeed);
            if (Mathf.Abs(transform.position.x) > TooFar || Mathf.Abs(transform.position.y) > TooFar || Mathf.Abs(transform.position.z) > TooFar)
                ResetBall();
        }
    }

    void ResetBall()
    {
        XSpeed = Multiplier - Random.value * Multiplier * 2;
        YSpeed = Multiplier - Random.value * Multiplier * 2;
        ZSpeed = Multiplier - Random.value * Multiplier * 2;
        transform.position = new Vector3(3 - Random.value * 6, 3 - Random.value * 6, 3 - Random.value * 6);
    }
}
