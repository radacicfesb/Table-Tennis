using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentMovingBack : MonoBehaviour
{
    [SerializeField] Transform opponentPaddle;
    [SerializeField] float movingSpeed = 150f;

    float step;
    // Start is called before the first frame update
    void Start()
    {
        step = movingSpeed * Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 backTargetPosition = new Vector3(4.51f, 1.2f, -4.42f);
        opponentPaddle.position = Vector3.Lerp(transform.position, backTargetPosition, step);
    }
}
