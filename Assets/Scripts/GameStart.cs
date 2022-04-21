using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void Start()
    {
        Screen.SetResolution(1920, 1080, true);     //해상도 Fix
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("Game");     //Game씬 로드
    }
    
    public void ClickExit()
    {
        Application.Quit();     //종료
    }
}