using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSet : MonoBehaviour
{
    void Start()
    {
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene("Game");
    }
}
