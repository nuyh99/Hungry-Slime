using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject fish;     //물고기(prefab) 객체
    public static int Count = 0;        //현재 물고기 수
    void Start()
    {
        InvokeRepeating("CreateFish", 0f, 0.5f);        //CreatedFish 함수를 0.5초마다 실행
    }

    void CreateFish()
    {
        if (Count < 15)     //현재 물고기가 15마리 미만이면 물고기 생성
        {
            Instantiate(fish);
            Count++;
        }
    }
}
