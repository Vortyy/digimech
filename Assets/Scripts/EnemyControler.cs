using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public bool kill = false;
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(kill == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void push(Vector2 force)
    {
        RB.AddForce(force);
    }
}
