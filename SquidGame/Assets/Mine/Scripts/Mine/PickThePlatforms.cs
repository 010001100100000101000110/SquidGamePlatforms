using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickThePlatforms : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platforms;
    [SerializeField]
    private int platformNumber;

    private void Awake()
    {
        platformNumber = Random.Range(0, 6);
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[platformNumber].SetActive(true);
        }        
    }
}
