using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 7.0f;
    private Vector3 _moveDirection = Vector3.zero;
    private SpriteRenderer _spriteRenderer;
    private bool isBoost;
    public MeterScript boostMeter;
    public float currentBoost;
    public float maxBoost = 80f;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        currentBoost = maxBoost;
        boostMeter.SetMaxBoost(maxBoost);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(moveSpeed);

        if (transform.localScale.x * 1.1f > col.transform.localScale.x)
        {
            transform.localScale += col.transform.localScale * 0.2f;
            if (moveSpeed > 2f)
                moveSpeed -= col.transform.localScale.x * 3;
        }
        else
        {
            transform.localScale -= col.transform.localScale * 0.3f;
            if (moveSpeed < 8)
                moveSpeed += col.transform.localScale.x * 3;
        }

        GameDirector.Count--;
        Destroy(col.GameObject());
    }
    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isBoost = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isBoost = false;
        }

            float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        _moveDirection = new Vector3(x, y, 0);
        
        boostMeter.SetBoost(currentBoost);
        if (isBoost&&currentBoost>0f)
        {
            transform.position += _moveDirection * (moveSpeed * Time.deltaTime) * 2f;
            currentBoost -= 60 * Time.deltaTime;
        }
        else
        {
            transform.position += _moveDirection * (moveSpeed * Time.deltaTime);
            if(currentBoost<=80)
                currentBoost += 20 * Time.deltaTime;
        }

        if (transform.localScale.x < 0.2f)
            Destroy(gameObject);
    }
}