using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1;
    private GameObject Hero;
    // Start is called before the first frame update
    void Start()
    {
        Hero = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(Hero.transform.position.x - transform.position.x, Hero.transform.position.y - transform.position.y);

        transform.position += distance * speed * Time.deltaTime;
    }
}
