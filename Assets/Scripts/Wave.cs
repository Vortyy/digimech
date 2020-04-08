using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Wave : MonoBehaviour
{
    [SerializeField] Text waveText;

    private float wave = 0;

    public void UpdateWave()
    {
        wave++;
        waveText.text = "Wave : " + wave.ToString();
    }
    public void DisplayWave(Text text)
    {
        text.text = "Wave : " + wave.ToString();
    }
}
