using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InflictPain : MonoBehaviour
{
    private PlayerControllerV2 playerController;
    [SerializeField] AudioSource deathSource;
    [SerializeField] Score scoreText;

    public float points;

    void Start()
    {
        playerController = GetComponent<PlayerControllerV2>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Input.GetMouseButton(0))
            {
                Destroy(collision.gameObject);
                deathSource.Play();
                if (playerController.isGrounded)
                {
                    scoreText.UpdateScore(points);
                }
                else
                {
                    scoreText.UpdateScore(points * 2.5f);
                }
                
            }           
        }
    }
}
