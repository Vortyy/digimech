using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InflictPain : MonoBehaviour
{
    [SerializeField] AudioClip death;
    [SerializeField] AudioSource deathSource;
    [SerializeField] Score scoreText;

    public float value = 1;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Input.GetMouseButton(0))
            {
                Destroy(collision.gameObject);
                deathSource.PlayOneShot(death);
                scoreText.UpdateScore(value);
            }           
        }
    }
}
