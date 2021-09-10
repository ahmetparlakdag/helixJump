using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasyButton : MonoBehaviour
{
    

    public void LoadScene()
    {
        PlayerPrefs.SetInt("Scene", 1);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
