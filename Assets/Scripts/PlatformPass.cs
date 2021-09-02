using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformPass : MonoBehaviour
{
    [SerializeField] private int passScore;


    private int platformChooser;
    [SerializeField]private PlatformSlice[] platformSlices;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(passScore);
    }
    void Start()
    {
        int emptyPlatform = Random.Range(0, platformSlices.Length);
        int deadlyPlatform = Random.Range(0, platformSlices.Length);
        while (deadlyPlatform == emptyPlatform)
        {
            deadlyPlatform = Random.Range(0, platformSlices.Length);
        }

        for (var i = 0; i < platformSlices.Length; i++)
        {
            if (i == emptyPlatform)
            {
                platformSlices[i].Init(SliceType.Empty);
            }else if (i == deadlyPlatform)
            {
                platformSlices[i].Init(SliceType.Deadly);
            }
            else
            {
                platformSlices[i].Init(SliceType.Normal);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}