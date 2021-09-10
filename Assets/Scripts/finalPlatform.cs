using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class finalPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerPrefs.SetInt("finalScore", GameManager.singleton.currentScore);
        GameManager.singleton.EndGame();
        SceneManager.LoadScene(4);
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
