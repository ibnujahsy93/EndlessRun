using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // variable untuk menyimpan nilai skor
    public TextMeshProUGUI scoreTextGameOver; // variable untuk menyimpan text game over
    public float scoreMultiply; // variabel sebagai pengkali dari skor
    public PlayerController pc;

    public float score; // variabel skor itu sendiri
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0.0f; // awal permainan skor 0
    }

    // Update is called once per frame
    void Update()
    {
        if(pc.gameOverStatus)
        {


        }else
        {
            score += scoreMultiply * Time.deltaTime; // nilai skor dihitung berdasarkan durasi permainan
            scoreText.text = "Score : " + Mathf.RoundToInt(score);	// menampilkan text skor
            scoreTextGameOver.text = "Score : " + Mathf.RoundToInt(score);	// menampilkan skor akhir saat game over
        }
        
    }
}
