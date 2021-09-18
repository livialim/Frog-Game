using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //biblioteca para poder manibular o canvas

public class gamecontroller : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;
    public static gamecontroller instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    public void UpdateScoreText()
    {
        scoreText.text = totalScore.ToString();
    }
}