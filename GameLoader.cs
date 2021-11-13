using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameLoader : MonoBehaviour
{
    private static GameLoader _instance;

    public static GameLoader Instance { get { return _instance; } }

    [SerializeField] GameObject namePanel;
    [SerializeField] GameObject startButton;
    [SerializeField] TMP_InputField nameInput;

  
   

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    

    public void ManageStartButton()
    {
        Debug.Log(nameInput.text);
        if(nameInput.text.Length > 0)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void LoadTrainingScene()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
