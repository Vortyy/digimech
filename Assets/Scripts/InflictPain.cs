using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InflictPain : MonoBehaviour
{
    [SerializeField] PlayerControllerV2 playerController;
    [SerializeField] AudioClip death;
    [SerializeField] AudioSource deathSource;
    [SerializeField] Score scoreText;

    public float value = 0;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Input.GetMouseButton(0))
            {
                Destroy(collision.gameObject);
                deathSource.PlayOneShot(death);
                if (playerController.isGrounded)
                {
                    scoreText.UpdateScore(value);
                }
                else
                {
                    scoreText.UpdateScore(value * 2.5f);
                }
                
            }           
        }
    }
}
