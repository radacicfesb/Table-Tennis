using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] Transform[] botAimTarget;

    float force = 7f;

    float offsetPosittion = 0.7f;

    GameObject score;
    Score scores;

    Vector3 direction;

    GameObject playersSideTrigger;
    CheckIfTriggered checkIfTriggered;

    AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
        scores = score.GetComponent<Score>();


        playersSideTrigger = GameObject.Find("PlayerSideTrigger");
        checkIfTriggered = playersSideTrigger.GetComponent<CheckIfTriggered>();

        myAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            
            if (checkIfTriggered.playerSideTrigger == false)
            {
                direction = botAimTarget[1].position - transform.position;
                other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 3.5f, 0);
            }
            else
            {
                direction = botAimTarget[Random.Range(0, botAimTarget.Length)].position - transform.position;
                other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 3.5f, 0);

            }
            myAudio.Play();
        }
    }


}
