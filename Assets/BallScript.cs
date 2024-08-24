using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;

    public Vector2 inDirection;

    void Start()
    {
        inDirection = new Vector2(-0.5f, -0.5f);
    }

    public void FixedUpdate()
    {
        transform.Translate(inDirection * speed * Time.deltaTime);
    }
    //On collision ricochet and move in bounce position//
    public void OnCollisionEnter2D(Collision2D collision)
    {
        // get the collision's normal
        var contactNormal = collision.contacts[0].normal;

        // reflects the ball in the oposite vector
        inDirection = Vector2.Reflect(inDirection, contactNormal);
        if(collision.contacts[0].collider.tag == "Block")
        {
            Destroy(collision.gameObject);//destroy the hitted block
            speed++;//increase the speed
        }
    }
}
