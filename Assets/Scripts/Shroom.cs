using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : Enemy
{
    public float walkDistance; 

    private bool walk; 

    void Start()
    {
    }

    protected override void Update()
    {
        base.Update();
        anim.SetBool("Walk", walk);

        if (Mathf.Abs(targetDistance) < walkDistance) {
            walk = true;
        }
    }

    private void FixedUpdate() 
    {
        if (walk) {
            if (targetDistance < 0) { 
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                if (!facingRight) { 
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
}
