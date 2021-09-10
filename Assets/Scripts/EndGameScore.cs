using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Your Score: " + PlayerPrefs.GetInt("finalScore").ToString();
    }
}
