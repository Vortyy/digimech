using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerControllerV2 : MonoBehaviour
{
    Rigidbody2D rb2d;

    public float speed = 20f;
    public float jumpVelocity = 20f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isGrounded = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Jump
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey("space"))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb2d.velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
        }

        // Lateral movement
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);      
        }
        else rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }

    // Detect collision with floor
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
