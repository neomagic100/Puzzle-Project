using UnityEngine;

public class SoccerBall : Item
{
    private Animator ballAnimator;
    private Rigidbody2D rb;
    private Vector2 atRest;

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

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "goal")
            print("Success!");
    }

    private bool ballMoving(Vector2 currSpeed)
    {
        if (Mathf.Abs(currSpeed.x - atRest.x) > 0.001 || Mathf.Abs(currSpeed.y - atRest.y) > 0.001)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
