using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject fish;
    public static int count = 0;
    void Start()
    {
        InvokeRepeating("createFish", 0f, 0.5f);
    }

    void createFish()
    {
        if (count < 15)
        {
            Instantiate(fish);
            count++;
        }
    }
    void Update()
    {
    }
}
