using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void ClickExit()
    {
        Application.Quit();
    }
}