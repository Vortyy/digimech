using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] Animator animatorWheel;
    [SerializeField] GameObject wheel;
    [SerializeField] GameObject tankChains;
    [SerializeField] GameObject floaty;
    GameObject bottom;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (tankChains.activeSelf)
            bottom = tankChains;
        else if (floaty.activeSelf)
            bottom = floaty;
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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            if (bottom != null)
                bottom.transform.position = new Vector3(transform.position.x, transform.position.y, 2);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            if (bottom != null)
                bottom.transform.position = new Vector3(transform.position.x, transform.position.y, 2);
        }
        
    }
}
