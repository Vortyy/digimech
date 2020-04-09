using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerV2 : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float direction;

    public bool kill = false;
    private const float size = 0.6f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        direction = player.transform.position.x - transform.position.x;
        Vector3 distance = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        transform.position += distance * Time.deltaTime;

        if (kill == true)
        {
            Destroy(this.gameObject);
        }

        if (direction > 0)
        {
            transform.localScale = new Vector2(size, size);
        }
        else if (direction < 0)
        {
            transform.localScale = new Vector2(-size, size);
        }
    }
}
