using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    private Vector3 moveDirection =Vector3.zero;
    private float size;

    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        throw new NotImplementedException();
    }

    void Update()
    {
        size = (float) Math.Pow(GetComponent<CircleCollider2D>().radius, 2);
        
        Vector3 playerPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (playerPosition.x < 0.02f) playerPosition.x = 0.02f;
        if (playerPosition.y < 0.02f) playerPosition.y = 0.02f;
        if (playerPosition.x > 0.98f) playerPosition.x = 0.98f;
        if (playerPosition.y > 0.98f) playerPosition.y = 0.98f;
        transform.position = Camera.main.ViewportToWorldPoint(playerPosition);
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDirection = new Vector3(x, y, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
