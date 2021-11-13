using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    //[SerializeField] Rigidbody ball;
    public Rigidbody ballRigidbody;
    //[SerializeField] AudioClip table;

    AudioSource myAudio;

    private void Awake()
    {
        ballRigidbody = GetComponent<Rigidbody>();

        ballRigidbody.isKinematic = true;
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
