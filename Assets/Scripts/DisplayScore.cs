using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] Text finalScore;

    private void Awake()
    {
        score.DisplayScore(finalScore);
    }
}
