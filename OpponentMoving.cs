using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMoving : MonoBehaviour
{
    [SerializeField] Transform opponentPaddle;
    [SerializeField] Transform ball;
    Vector3 targetPosition;
    [SerializeField] float movingSpeed = 10f;

    float offset = 0.7f;
    float step;
    // Start is called before the first frame update
    void Start()
    {
        step = movingSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //opponentPaddle.position = new Vector3(ball.position.x, 1.3f, ball.position.z + offset);
        targetPosition = new Vector3(ball.position.x, 1.3f, ball.position.z + offset);
        opponentPaddle.position = Vector3.Lerp(new Vector3 (Mathf.Clamp(transform.position.x, -3f,0),transform.position.y,transform.position.z), targetPosition, step);
        
    }
    
}

