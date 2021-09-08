using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("xd");
        GameManager.singleton.EndGame();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
