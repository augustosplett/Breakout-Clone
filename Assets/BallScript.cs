using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    public Vector2 inDirection;
    //Set the moving speed//

    void Start()
    {
        inDirection = new Vector2(0.5f, 0.5f);
        //rb = GetComponent<Rigidbody2D>();
        //LaunchBall();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //void LaunchBall()
    //{
    //    Vector3 direction = new Vector3(1, -1, 0).normalized;
    //    rb.velocity = direction * speed;
    //}

    public void FixedUpdate()
    {
        transform.Translate(inDirection * speed * Time.deltaTime);
    }
    //On collision ricochet and move in bounce position//
    public void OnCollisionEnter2D(Collision2D collision)
    {
        var contactPoint = collision.contacts[0].point;
        Vector2 ballLocation = transform.position;
        var inNormal = (ballLocation - contactPoint).normalized;
        inDirection = Vector2.Reflect(inDirection, inNormal);
    }
}
