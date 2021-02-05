using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject OneBallPrefab;
    public GameObject EightBallPrefab;
    public GameObject ThirteenBallPrefab;
    public GameObject ShootingStarPrefab;
    public int Score = 0;
    public int ThirteenBallPoints = 100;
    public int ShootingStarPoints = 350;
    public bool isGameRunning = false;
    public bool isEightBallOut = false;
    public int BallCount = 0;
    public int MaxBallCount = 15;   
    public Text ScoreText;
    public Button PlayAgainButton;
   


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AddOneBall", 1F, 1F);
        InvokeRepeating("AddEightBall", 5F, 2);
        InvokeRepeating("AddThirteenBall", 10F, 3);
        InvokeRepeating("AddShootingStar", 11F, 11);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Score.ToString();
    }   

    public void StartGame()
    {
        PlayAgainButton.gameObject.SetActive(false);
        Score = 0;
        BallCount = 0;
        isGameRunning = true;
    }

    public void EndGame()
    {
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("GameController"))
        {
            Destroy(ball);
        }
        isGameRunning = false;
        PlayAgainButton.gameObject.SetActive(true);
    }

    void AddOneBall()
    {
        if (isGameRunning)
        {
            Instantiate(OneBallPrefab);
            BallCount++;
            if (BallCount >= MaxBallCount)
            {
                EndGame();
            }
        }
    }

    void AddEightBall()
    {
        if (isGameRunning)
        {
            if (!isEightBallOut)
            {
                Instantiate(EightBallPrefab);
                isEightBallOut = true;
            }
        }
    }

    void AddThirteenBall()
    {
        if (isGameRunning)
        {
            Instantiate(ThirteenBallPrefab);
        }
    }    

    void AddShootingStar()
    {
        if (isGameRunning)
        {
            Instantiate(ShootingStarPrefab);
        }
    }

    public void ClickedOneBall()
    {
        Score += 10;
        BallCount--;    
    }


    public void ClickedEightBall()
    {
        EndGame();
    }

    public void ClickedThirteenBall()
    {
        Score += ThirteenBallPoints;
        BallCount--;
    }

    public void ClickedShootingStar()
    {
        Score += ShootingStarPoints;
    }


}
