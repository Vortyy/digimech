using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerV2 : MonoBehaviour
{

    [SerializeField] GameObject wheel;
    [SerializeField] Animator animatorWheel;
    public Rigidbody2D rb;

    public bool kill = false;
    public float health = 20;
    private float size = 0.6f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (kill == true)
        {
            Destroy(this.gameObject);
        }

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

        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(size, size);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(-size, size);
        }
    }

    public void Push(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            kill = true;
        }
    }
}
