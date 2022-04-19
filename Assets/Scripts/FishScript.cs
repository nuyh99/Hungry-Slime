using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FishScript : MonoBehaviour
{
    private bool right;
    private float speed;
    private Vector3 pos;

    private Vector3 getRandomPosition()
    {
        float x = (Random.Range(0, 2) * 2 - 1) * 12;
        float y = Random.Range(-4, 4);
        return new Vector3(x, y, 0);
    }

    private float getRandomSize()
    {
        return Random.Range(0f, 1f);
    }
    void Start()
    {
        GetComponent<Transform>().position = getRandomPosition();
        pos = GetComponent<Transform>().position;
        
        if (transform.position.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        transform.localScale =Vector3.one*getRandomSize();
        
        if (GetComponent<SpriteRenderer>().flipX == true)
            speed = Random.Range(1f, 9f);
        else
            speed = Random.Range(-1f, -9f);
    }

    void Update()
    {
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (transform.position.x > 12 || transform.position.x < -12)
        {
            GameDirector.count--;
            Destroy(gameObject);
        }
    }
}