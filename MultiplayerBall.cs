using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerBall : NetworkBehaviour
{
    public Rigidbody multiBallRigidbody;
    //[SerializeField] AudioClip table;

    AudioSource myAudio;

   // [SyncVar]
    //Vector3 ballPos;
    private void Awake()
    {
        multiBallRigidbody = GetComponent<Rigidbody>();

        multiBallRigidbody.isKinematic = true;
    }

    private void Update()
    {
        //ballPos = multiBallRigidbody.position;
    }

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Table"))
            myAudio.Play();
    }
}
