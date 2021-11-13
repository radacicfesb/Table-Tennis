using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    //GameObject mainCamera;
    [SerializeField] Transform start;
    [SerializeField] Transform playerPositionOffset;
    Transform offset;
    // Start is called before the first frame update
    void Start()
    {
        start.position = transform.position;
        playerPositionOffset.position = offset.position;
        offset.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedCamera()
    {
        transform.position = transform.position + offset.position;
    }
}
