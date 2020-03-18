using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Animator animatorWheel;
    [SerializeField] Animator animatorScissors;
    [SerializeField] GameObject wheel;
    [SerializeField] GameObject scissors;

    private float size = 0.6f;
    public bool animBool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (wheel.activeSelf)
        {
            if (rb.velocity.x > 0 || rb.velocity.x < 0)
            {
                animatorWheel.SetBool("isMoving", true);
            }
            else
            {
                animatorWheel.SetBool("isMoving", false);
            }
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            transform.localScale = new Vector2(size, size);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.localScale = new Vector2(-size, size);
        }

        if (Input.GetKey("k"))
        {
            if (scissors.activeSelf)
                animatorScissors.Play("Scissors");
        }
        else
        {
            if (scissors.activeSelf)
                animatorScissors.Play("ScissorsIdle");
        }
    }
}
