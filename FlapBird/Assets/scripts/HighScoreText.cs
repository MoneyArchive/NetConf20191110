using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighScoreText : MonoBehaviour
{
    private Text highScore;

    void OnEnable()
    {
        highScore = GetComponent<Text>();
        highScore.text = "HighScore: "+PlayerPrefs.GetInt("HighScore").ToString();
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
