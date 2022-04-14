using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : Item
{
    private Rigidbody2D obj;
    public int force;

    void Start()
    {
        //YourAudioSource.volume = AudioManager.instance.volume; // Uncomment when you have an Audio Source
    }
    private void OnTriggerStay2D (Collider2D item)
    {
        if (item.gameObject.CompareTag("Item"))
        {
            obj = item.GetComponent<Rigidbody2D>();
            obj.AddForce(new Vector2(obj.velocity.x + force, obj.velocity.y));
        }
    }
}
