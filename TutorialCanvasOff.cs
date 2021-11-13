using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCanvasOff : MonoBehaviour
{
    Canvas tutorialCanvas;

    Touch touch;
    // Start is called before the first frame update
    void Start()
    {
        tutorialCanvas = GetComponent<Canvas>();
        tutorialCanvas.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            tutorialCanvas.gameObject.SetActive(false);
        }
    }
}
