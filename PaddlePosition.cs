using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PaddlePosition : MonoBehaviour
{

    Touch touch;

    public Rigidbody paddle;
    float speed = 0.01f;

    [SerializeField] float xMin = -6f;
    [SerializeField] float xMax = -0.25f;
    [SerializeField] float zMin = -8f;
    [SerializeField] float zMax = -3f;

    [SerializeField] Transform[] aimTarget;
    float force = 10f;

    GameObject ball;
    GameObject playersSideTrigger;
    GameObject opponentsSideStrigger;
    //GameObject score;

    BallMoving ballMoving;
    CheckIfTriggered checkIfTriggered;
    CheckIfTriggered checkIfOppTriggered;
    //Score scores;

    Vector3 direction;

    AudioSource myAudio;

    void Start()
    {

         ball = GameObject.FindGameObjectWithTag("Ball");
         ballMoving = ball.GetComponent<BallMoving>();

        playersSideTrigger = GameObject.Find("PlayerSideTrigger");
        checkIfTriggered = playersSideTrigger.GetComponent<CheckIfTriggered>();

        opponentsSideStrigger = GameObject.Find("OpponentSideTrigger");
        checkIfOppTriggered = opponentsSideStrigger.GetComponent<CheckIfTriggered>();

        myAudio = GetComponent<AudioSource>();

        //force = force * Time.deltaTime;
       // paddle = GetComponent<Rigidbody>();

       //paddle.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;

        // score = GameObject.Find("Score");
        //scores = score.GetComponent<Score>();
    }

    void Update()
    {
        TouchInput();
    }
           
       
    

    void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (ballMoving.ballRigidbody.isKinematic == true)
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x - touch.deltaPosition.x * speed, -6f, -3f), transform.position.y, Mathf.Clamp(transform.position.z + touch.deltaPosition.x * speed, -6f, -6f));
                else
                    transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.y * speed, xMin, xMax), transform.position.y, Mathf.Clamp(transform.position.z - touch.deltaPosition.x * speed, zMin, zMax));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballMoving.ballRigidbody.isKinematic = false;
           
            
           // if(checkIfTriggered.playerSideTrigger == false && checkIfOppTriggered.oppSideTrigger == false)
            //{
              //  direction = aimTarget[3].position-transform.position;
                //other.GetComponent<Rigidbody>().velocity = direction.normalized * force * 2f + new Vector3(0, -2f, 0);
            //}
            //else
            //{
                direction = aimTarget[Random.Range(0, 2)].position - transform.position;
                other.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 3.5f, 0);

            //}
            myAudio.Play();
        }
    }
}
