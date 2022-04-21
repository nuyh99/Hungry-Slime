using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;      //텍스트 객체
    public int a;           //int로 받기
    void Start()
    {
        a = (int) PlayerScript.Score_count;
        
        score.text = "SCORE : ";
        score.text += a;
    }
}
