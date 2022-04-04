using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BilliardsBall : Item
{
    private float old_position_x, old_position_y;
    private Animator ballAnimator;
    private Rigidbody2D rb;
    private Vector2 atRest;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "goal")
            print("Success!");
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atRest = Vector2.zero;

        ballAnimator = GetComponent<Animator>();

        if (ballAnimator == null)
        {
            Debug.LogError("Cannot load ANIMATOR for the Blower Item.");
        }
        ballAnimator.StopPlayback();

    }

    private void Update()
    {
        if (ballMoving(rb.velocity))
        {
            ballAnimator.StartPlayback();
        }
        else
        {
            ballAnimator.StopPlayback();
        }
    }

    private bool ballMoving(Vector2 currSpeed)
    {
        if (Math.Abs(currSpeed.x - atRest.x) > 0.001 || Math.Abs(currSpeed.y - atRest.y) > 0.001)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
