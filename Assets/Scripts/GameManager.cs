using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentScore;
    public int highScore;
    public static GameManager singleton;

    void Start()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Debug.LogError("Check singleton!");
        }
        highScore = PlayerPrefs.GetInt("Highest");
    }



    void Update()
    {
        
    }

    public void NextLevel()
    {
        Debug.Log("Next Level!!!");
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level!!!");
        FindObjectOfType<ballBehaviour>().ResetPos();
        FindObjectOfType<helixBehaviour>().ResetRotation();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("Highest", highScore);
        }
    }

}
