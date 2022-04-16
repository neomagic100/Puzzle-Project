using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D item)
    {
        if (item.gameObject.name == "SoccerBall(Clone)")
        {
            Debug.Log("Success!");
        }
    }
}
