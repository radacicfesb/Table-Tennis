using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEditor.SceneManagement;

public class MultiPlayer : NetworkBehaviour
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

    MultiplayerBall multiplayerBall;
    CheckIfTriggered checkIfTriggered;
    CheckIfTriggered checkIfOppTriggered;
    //Score scores;

    Vector3 direction;

    AudioSource myAudio;

    [SerializeField] Camera cam1;

    [SerializeField] Transform netPosition;
    public Transform leftRacketSpawn;
    public Transform rightRacketSpawn;
    //NetworkManager numPlayers;
    public Vector3 startPosition;

    private void Awake()
    {
        startPosition = transform.position;
    }

    void Start()
    {
       // Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;

        playersSideTrigger = GameObject.Find("PlayerSideTrigger");
        checkIfTriggered = playersSideTrigger.GetComponent<CheckIfTriggered>();

        opponentsSideStrigger = GameObject.Find("OpponentSideTrigger");
        checkIfOppTriggered = opponentsSideStrigger.GetComponent<CheckIfTriggered>();

        myAudio = GetComponent<AudioSource>();

       if (isLocalPlayer) return;
        cam1.enabled = false;

       


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
        if (isLocalPlayer)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                   // cameraPos.FixedCamera();
                    if (GameObject.FindGameObjectWithTag("BallM") != null)
                    {

                        ball = GameObject.FindGameObjectWithTag("BallM");
                        multiplayerBall = ball.GetComponent<MultiplayerBall>();
                        if(startPosition == leftRacketSpawn.position)
                            transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.y * speed, startPosition.x , netPosition.position.x), transform.position.y, Mathf.Clamp(transform.position.z - touch.deltaPosition.x * speed, zMin, zMax));
                        else if(startPosition == rightRacketSpawn.position)
                            transform.position = new Vector3(Mathf.Clamp(transform.position.x - touch.deltaPosition.y * speed, netPosition.position.x, startPosition.x), transform.position.y, Mathf.Clamp(transform.position.z + touch.deltaPosition.x * speed, zMin, zMax));
                    }
                        
                    
                    else
                        transform.position = new Vector3(Mathf.Clamp(transform.position.x - touch.deltaPosition.x * speed, -6f, -3f), transform.position.y, Mathf.Clamp(transform.position.z - touch.deltaPosition.x * speed, -6f, -6f));
                }
                
            }
        }
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BallM"))
        {
            multiplayerBall.multiBallRigidbody.isKinematic = false;


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
