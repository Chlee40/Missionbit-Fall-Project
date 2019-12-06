using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float xspeed;
    public float yspeed;
    public bool goingRight;
    public float timeInterval;
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            xspeed *= -1f;
        }

    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        GoBall();

    }

    private void Update()
    {
        transform.Translate(new Vector3(xspeed, yspeed, 0f));

        if (timeInterval > 2)
        {
            GoBall();
            timeInterval = 0;
        }
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        xspeed = 0;
        yspeed = 0;

    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "PaddlePlayer")
        { 
        xspeed *= -1f;
        }
        
        else if (coll.gameObject.tag == "topbot")
        {
        yspeed *= -1f;
        }
        else if (coll.gameObject.tag == "leftright")
        {
            ResetBall();
            timeInterval += Time.deltaTime;
        }
    }
}