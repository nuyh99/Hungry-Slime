using UnityEngine;
using Random = UnityEngine.Random;

public class FishScript : MonoBehaviour
{
    private bool _isRight;      //오른쪽을 보고 있는지
    private float _speed;       //물고기의 속도
    private Vector3 _pos;       //물고기의 현재 포지션

    private Vector3 getRandomPosition()     //랜덤 시작 포지션
    {
        float x = (Random.Range(0, 2) * 2 - 1) * 12;
        float y = Random.Range(-4, 4);
        return new Vector3(x, y, 0);
    }

    private float getRandomSize()       //랜덤 사이즈
    {
        return Random.Range(0f, 0.8f);
    }

    void Start()
    {
        GetComponent<Transform>().position = getRandomPosition();       //랜덤 시작 포지션으로 세팅
        _pos = GetComponent<Transform>().position;

        if (transform.position.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;        //시작 위치에 따른 물고기의 방향

        Vector3 size = Vector3.one * getRandomSize();
        transform.localScale = size;        //랜덤 사이즈로 localScale 세팅

        _speed = GetComponent<SpriteRenderer>().flipX ? Random.Range(1f, 9f) : Random.Range(-1f, -9f);      //랜덤 스피드 세팅
    }

    void Update()
    {
        _pos.x += _speed * Time.deltaTime;
        transform.position = _pos;

        if (transform.position.x > 12 || transform.position.x < -12)
        {
            GameDirector.Count--;       //현재 물고기 카운트 --
            Destroy(gameObject);        //물고기 객체 제거
        }
    }
}