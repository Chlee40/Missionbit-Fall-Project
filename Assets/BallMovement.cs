using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float xspeed;
    public float yspeed;
    public bool goingRight;
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
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            yspeed *= -1f;
        }
    }
}