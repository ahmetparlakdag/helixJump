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

    public void EndGame()
    {
        Debug.Log("Game Over!!!");
    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level!!!");
        FindObjectOfType<ballBehaviour>().ResetPos();
        FindObjectOfType<helixBehaviour>().ResetRotation();
        FindObjectOfType<helixBehaviour>().recreatePlatforms();
        ballBehaviour.comboCounter = 0;
        currentScore = 0; 
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
