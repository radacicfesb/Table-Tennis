using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinConditionPlayer : MonoBehaviour
{

    public bool OppWinTriggered = false;
    public bool playerWinTriggered = false;

    [SerializeField] Rigidbody ball;
    [SerializeField] Transform playerPaddle;

    GameObject opponentSideTrigger;
    GameObject playersSideTrigger;
    GameObject score;
    //GameObject opponentSideTrigger;

    CheckIfTriggered checkIfOppTriggered;
    CheckIfTriggered checkIfTriggered;
    Score scores;

    Vector3 ballPositionOnBeggining;
    Vector3 playerPaddlePositionOnBeggining;
    // Vector3 currentBallPosition;


    // Start is called before the first frame update
    void Start()
    {
        opponentSideTrigger = GameObject.Find("OpponentSideTrigger");
        checkIfOppTriggered = opponentSideTrigger.GetComponent<CheckIfTriggered>();

        playersSideTrigger = GameObject.Find("PlayerSideTrigger");
        checkIfTriggered = playersSideTrigger.GetComponent<CheckIfTriggered>();



        score = GameObject.Find("Score");
        scores = score.GetComponent<Score>();

        ballPositionOnBeggining = ball.position;

        playerPaddlePositionOnBeggining = playerPaddle.position;

        // opponentSideTrigger = GameObject.Find("OpponentSideTrigger");
        // checkIfOppTriggered = opponentSideTrigger.GetComponent<CheckIfTriggered>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //currentBallPosition = ball.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkIfTriggered.playerSideTrigger == false)
        {
            scores.playerScore++;
            BeginningState();
            playerWinTriggered = true;
            
        }
        else if (checkIfTriggered.playerSideTrigger == true)
        {
            scores.opponentScore++;
            BeginningState();
            OppWinTriggered = true;
        }
    }

    private void BeginningState()
    {
        ball.isKinematic = true;
        ball.position = ballPositionOnBeggining;
        playerPaddle.position = playerPaddlePositionOnBeggining;
        checkIfTriggered.playerSideTrigger = false;
        checkIfOppTriggered.oppSideTrigger = false;
    }
}
