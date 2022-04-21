using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void ClickExit()
    {
        Application.Quit();
    }
}