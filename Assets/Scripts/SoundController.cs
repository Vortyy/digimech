using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] GameObject scissors;
    [SerializeField] GameObject glove;
    [SerializeField] AudioSource scissorsSnip;
    [SerializeField] AudioSource glovePunch;
    [SerializeField] AudioClip scissorsSound;
    [SerializeField] AudioClip gloveSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (scissors.activeSelf)
            {
                scissorsSnip.PlayOneShot(scissorsSound);
            }
            
            if (glove.activeSelf)
            {
                glovePunch.PlayOneShot(gloveSound);
            }
        }
    }
}
