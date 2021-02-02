using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);

        transform.position += distance * speed * Time.deltaTime;
    }
}
