using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public int a;
    void Start()
    {
        a = (int) PlayerScript.Score_count;
        
        score.text = "SCORE : ";
        score.text += a;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
