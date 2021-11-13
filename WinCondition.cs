using Mirror.Examples.Pong;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public bool OppWinTriggered = false;
    public bool playerWinTriggered = false;

    //[SerializeField] Rigidbody ball;
    [SerializeField] Transform playerPaddle;

    GameObject ball;
    Rigidbody ballRigidbody;

    GameObject opponentSideTrigger;
    GameObject playersSideTrigger;
    GameObject score;


    //CheckIfTriggered checkIfTriggered;
    CheckIfTriggered checkIfTriggered;
    CheckIfTriggered checkIfOppTriggered;
    Score scores;
    //PaddlePosition paddlePosition;

    Vector3 ballPositionOnBeggining;
    Vector3 playerPaddlePositionOnBeggining;
    //Vector3 currentBallPosition;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
        scores = score.GetComponent<Score>();

        playersSideTrigger = GameObject.Find("PlayerSideTrigger");
        checkIfTriggered = playersSideTrigger.GetComponent<CheckIfTriggered>();

        opponentSideTrigger = GameObject.Find("OpponentSideTrigger");
        checkIfOppTriggered = opponentSideTrigger.GetComponent<CheckIfTriggered>();

        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();

        playerPaddlePositionOnBeggining = playerPaddle.position;

        ballPositionOnBeggining = ballRigidbody.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // currentBallPosition = ball.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(checkIfOppTriggered.oppSideTrigger == false)
        {
            scores.opponentScore++;
            BeginningState();
            OppWinTriggered = true;
            
        }
        else if (checkIfOppTriggered.oppSideTrigger == true)
        {
            scores.playerScore++;
            BeginningState();
            playerWinTriggered = true;                  
        }
    }

     void BeginningState()
    {
        ballRigidbody.isKinematic = true;
        ballRigidbody.position = ballPositionOnBeggining;
        playerPaddle.position = playerPaddlePositionOnBeggining;
        checkIfOppTriggered.oppSideTrigger = false;
        checkIfTriggered.playerSideTrigger = false;
    }
}

