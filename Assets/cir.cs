using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cir : Item
{
    public GameObject circle;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        circle = new GameObject("ball");
        rb = circle.AddComponent<Rigidbody2D>();
        rb.mass = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
