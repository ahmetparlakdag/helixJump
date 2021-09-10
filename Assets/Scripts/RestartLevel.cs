using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Restart()
    {
        int load = PlayerPrefs.GetInt("Scene");
        SceneManager.LoadScene(load);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
