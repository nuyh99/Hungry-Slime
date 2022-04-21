using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSet : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R))        //R키를 누르면 Game 씬 시작
            SceneManager.LoadScene("Game");
    }
}
