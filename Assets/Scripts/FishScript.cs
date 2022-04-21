using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishScript : MonoBehaviour
{
    private bool _isRight;
    private float _speed;
    private Vector3 _pos;

    private Vector3 getRandomPosition()
    {
        float x = (Random.Range(0, 2) * 2 - 1) * 12;
        float y = Random.Range(-4, 4);
        return new Vector3(x, y, 0);
    }

    private float getRandomSize()
    {
        return Random.Range(0f, 0.8f);
    }

    void Start()
    {
        GetComponent<Transform>().position = getRandomPosition();
        _pos = GetComponent<Transform>().position;

        if (transform.position.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;

        Vector3 size = Vector3.one * getRandomSize();
        transform.localScale = size;

        _speed = GetComponent<SpriteRenderer>().flipX ? Random.Range(1f, 9f) : Random.Range(-1f, -9f);
    }

    void Update()
    {
        _pos.x += _speed * Time.deltaTime;
        transform.position = _pos;

        if (transform.position.x > 12 || transform.position.x < -12)
        {
            GameDirector.Count--;
            Destroy(gameObject);
        }
    }
}