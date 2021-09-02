using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Highest: " + GameManager.singleton.highScore.ToString();
        scoreText.text = "Score: " + GameManager.singleton.currentScore.ToString();
    }
}
