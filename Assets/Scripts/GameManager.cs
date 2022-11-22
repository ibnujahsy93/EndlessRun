using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextGameOver;
    public float scoreMultiply;
    public PlayerController pc;

    public float score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.gameOverStatus)
        {


        }else
        {
            score += scoreMultiply * Time.deltaTime;
            scoreText.text = "Score : " + Mathf.RoundToInt(score);
            scoreTextGameOver.text = "Score : " + Mathf.RoundToInt(score);
        }
        
    }
}
