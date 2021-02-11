using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsters : Enemy
{
    void Start()
    {
    }

    protected override void Update()
    {
        base.Update();
    }
   

    private void FixedUpdate() 
    {
        if (targetDistance < 0) { 
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if (!facingRight)
            { 
                Flip();
            }
        } else {       
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            if (facingRight) {
                Flip();
            }
        }
    }
}
