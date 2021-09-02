using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.singleton.NextLevel();
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
