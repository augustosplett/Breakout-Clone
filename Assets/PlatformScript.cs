using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed = 5f; 
    public float distance = 10f; 
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1);
        }
    }

    private void Move(int direction)
    {
        Vector3 movement = new Vector3(direction, 0, 0) * speed * Time.deltaTime;
        transform.position += movement;

        //here I can define the range of the platform movement.
        float distanceMoved = Vector3.Distance(startPosition, transform.position);
        if (distanceMoved > distance)
        {
            transform.position = startPosition + new Vector3(direction * distance, 0, 0);
        }
    }
}

