using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfTriggered : MonoBehaviour
{
   public bool oppSideTrigger = false;
   public bool playerSideTrigger = false;

    //moran nac gameobject s druge strane i ugasit njihov trigger i onda ce sve radit

    GameObject playersSide;
    GameObject oppsSide;

    CheckIfTriggered checkIfPleyaTriggered;
    CheckIfTriggered checkIfOppTriggered;

    // Start is called before the first frame update
    void Start()
    {
        playersSide = GameObject.Find("PlayerSideTrigger");
        checkIfPleyaTriggered = playersSide.GetComponent<CheckIfTriggered>();

        oppsSide = GameObject.Find("OpponentSideTrigger");
        checkIfOppTriggered = oppsSide.GetComponent<CheckIfTriggered>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("OppSide"))
        {
            oppSideTrigger = true;
            playerSideTrigger = false;
            checkIfPleyaTriggered.playerSideTrigger = false;
        }
         else if (gameObject.CompareTag("PlayerSide"))
         {
            oppSideTrigger = false;
            playerSideTrigger = true;
            checkIfOppTriggered.oppSideTrigger = false;
         }
    }
}
