using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.SetActive(false);
        ballBehaviour.boostActive = true;
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
