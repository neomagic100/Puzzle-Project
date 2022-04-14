using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    private Rigidbody2D obj; // object that collides with the fan's hitbox

    public int force;

    public void onCollisionEnter2D(Collider2D item)
    {
        if (item.gameObject.CompareTag("Item"))
        {
            obj = item.GetComponent<Rigidbody2D>();

            obj.AddForce(new Vector2(force, 0));
        }
    }
}
