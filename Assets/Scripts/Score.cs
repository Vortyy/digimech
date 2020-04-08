using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public float score = 0;

    public void UpdateScore(float value)
    {
        score += value;
        scoreText.text = "Score : " + score.ToString();
    }
    public void DisplayScore(Text text)
    {
        text.text = "Score : " + score.ToString();
    }
}
