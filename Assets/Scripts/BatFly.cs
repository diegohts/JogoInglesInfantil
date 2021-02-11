using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFly : Enemy
{
    void Start()
    {
    }

    protected override void Update() 
    {
        base.Update(); 

        if (targetDistance < 0) {
            if (!facingRight) { 
                Flip();
            }
        } else {
            if (facingRight) { 
                Flip();
            }
        }

        if (Mathf.Abs(targetDistance) < attackDistance) { 
            transform.position = Vector3.MoveTowards(transform.position, 
                target.transform.position, speed * Time.deltaTime);
        }
    }
}
