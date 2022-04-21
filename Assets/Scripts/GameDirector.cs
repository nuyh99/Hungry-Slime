using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject fish;
    public static int Count = 0;
    void Start()
    {
        InvokeRepeating("CreateFish", 0f, 0.5f);
    }

    void CreateFish()
    {
        if (Count < 15)
        {
            Instantiate(fish);
            Count++;
        }
    }
    void Update()
    {
    }
}
