using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MultiScore : NetworkBehaviour
{
    [SerializeField] Text oppScore;
    [SerializeField] Text plScore;

   // [SerializeField] Canvas playerWonCanvas;
    

    [SerializeField] Collider playerCollider;


    public int playerScore;
    public int opponentScore;


    void Start()
    {
        //playerWonCanvas.gameObject.SetActive(false);

    }


    void Update()
    {
        oppScore.text = opponentScore.ToString();
        plScore.text = playerScore.ToString();

        if (playerScore >= 11)
            PlayerWon();
    }

    void PlayerWon()
    {
       // playerWonCanvas.gameObject.SetActive(true);
        playerCollider.enabled = false;
    }
}