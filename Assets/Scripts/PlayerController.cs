using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RB;

    public GameObject Groundpoint;
    public GameObject Arm;

    public float speed = 5f;
    public float facingX = 0;
    public float facingY = 0;

    public float currentFacingX = 0;
    public float currentFacingY = 0;

    public bool Isgrounded = false;
    public bool IsActionPaused = false;
    public bool Attackcooldown = false;

    public int ActionPauseCounter = 2;

    public Vector3 mousePoint;
    public Vector2 mousePointN;

    void Start()
    {
        RB = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float move = 0;

        facingX = 0;
        facingY = 0;
        //////////////////////////////////////////////////////////////////////////////////////////////////

        Vector3 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePointN = mousePoint - transform.position;
        mousePointN.Normalize();

        if (mousePointN.x >= 0)
        { facingX = 1; }
        else
        { facingX = -1; }
        if (mousePointN.y >= 0)
        { facingY = 1; }
        else
        { facingY = -1; }


        mousePointN = new Vector2(transform.position.x + mousePointN.x, transform.position.y + mousePointN.y);
        Arm.transform.position = mousePointN;


        //////////////////////////////////////////////////////////////////////////////////////////
        Collider2D IsgroundedCheck = Physics2D.OverlapPoint(Groundpoint.transform.position);
        if (IsgroundedCheck != null || IsActionPaused == true)
        {
            Isgrounded = true;

            if (IsgroundedCheck != null)
            {
                ActionPauseCounter = 2;
            }
        }
        else
        {
            Isgrounded = false;
        }
        /////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.D))
        {
            move = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            move = -1;
        }

        if (Input.GetKey(KeyCode.W))
        {
        }

        if (Input.GetKey(KeyCode.S))
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetMouseButtonDown(0))
        {
            Attack(facingX);

            IsActionPaused = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpecialAttack(facingX);

            IsActionPaused = false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Isgrounded || IsActionPaused)
            {
                RB.AddForce(new Vector2(0, 1f) * 900);
                IsActionPaused = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            if (!IsActionPaused && !Isgrounded && (ActionPauseCounter > 0))
            {
                ActionPauseCounter -= 1;
                StartCoroutine(ActionPausedTimer());

            }
            else
            {
                IsActionPaused = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////



        if (!IsActionPaused)
        {
            Vector3 movement = new Vector3(move, 0);
            transform.position += movement * speed * Time.deltaTime;

            if (RB.velocity.x > 5)
            {
                RB.velocity = new Vector3(10, RB.velocity.y, 0);
            }

            if (RB.velocity.x < -5)
            {
                RB.velocity = new Vector3(-10, RB.velocity.y, 0 );
            } 
        }

        if (IsActionPaused)
        {
            RB.velocity = new Vector3(0 , 0, 0);
            RB.AddForce(new Vector2(0, 1) * 42);
        }
    }

    IEnumerator ActionPausedTimer()
    {
        IsActionPaused = true;
        yield return new WaitForSeconds(1);
        IsActionPaused = false;
    }

    void Attack(float facingx)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(Arm.transform.position, 0.5f);

        if (collider.Length > 0)
        {
            for (int x = 0; x != collider.Length; x++)
            {
                if (collider[x].gameObject.name == "Enemy")
                {
                    collider[x].gameObject.GetComponent<EnemyControler>().push(new Vector2(100 * facingx, 100));
                    Debug.Log(collider[x].gameObject.name);
                }
            }
        }
    }

    void SpecialAttack(float facingx)
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(Arm.transform.position, 0.5f);

        if (collider.Length > 0)
        {
            for (int x = 0; x != collider.Length; x++)
            {
                if (collider[x].gameObject.name == "Enemy")
                {
                    collider[x].gameObject.GetComponent<EnemyControler>().push(new Vector2(10000 * facingx, 100));
                    Debug.Log(collider[x].gameObject.name);
                }
            }
        }
    }

}

