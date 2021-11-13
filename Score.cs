using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text oppScore;
    [SerializeField] Text plScore;

    [SerializeField] Canvas playerWonCanvas;
    [SerializeField] Canvas johnWonCanvas;

    [SerializeField] Collider playerCollider;
    

    public int playerScore;
    public int opponentScore;

    
    void Start()
    {
        playerWonCanvas.gameObject.SetActive(false);
        johnWonCanvas.gameObject.SetActive(false);
    }

    
    void Update()
    {
        oppScore.text = opponentScore.ToString();
        plScore.text = playerScore.ToString();

        if (playerScore >= 11)
            PlayerWon();
        if (opponentScore >= 11)
            JohnWon();
    }

    void PlayerWon()
    {
        playerWonCanvas.gameObject.SetActive(true);
        playerCollider.enabled = false;
    }

    void JohnWon()
    {
       johnWonCanvas.gameObject.SetActive(true);
       playerCollider.enabled = false;
    }
}
