using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : Item
{
    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "goal")
            print("Success!");
    }

}
