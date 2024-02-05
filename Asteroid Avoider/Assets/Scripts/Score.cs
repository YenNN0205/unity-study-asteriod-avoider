using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public float scoreRate;
    public TMP_Text scoreText;
    private float score;
    private bool isCount = true;
    private void Update()
    {  
        if(!isCount) {return;}
        else
        {  
        score +=Time.deltaTime*scoreRate;
        scoreText.text = Mathf.FloorToInt(score).ToString();
        }


    }
    public float ScoreEndGame()
    {
        isCount = false;
        scoreText.text = string.Empty;
        return score = Mathf.FloorToInt(score);
    }

}
