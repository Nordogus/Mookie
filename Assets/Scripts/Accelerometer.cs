using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.acceleration.x, Input.acceleration.y, 0) * speed;

        MoveDirection();
    }
    void MoveDirection()
    {
        float textX = Input.acceleration.x;
        float textY = Input.acceleration.y;

        if (textX < 0)
        {
            textX *= -1;
        }
        if (textY < 0)
        {
            textY *= -1;
        }

        if (textX < textY)
        {
            if (Input.acceleration.y < 0)
            {
                //move dawn
                anim.SetInteger("direct", 0);
            }
            else
            {
                // move up
                anim.SetInteger("direct", 1);
            }
        }
        else
        {
            if (Input.acceleration.x < 0)
            {
                // move left
                anim.SetInteger("direct", 2);
            }
            else
            {
                // move right
                anim.SetInteger("direct", 3);
            }
        }
    }
}
