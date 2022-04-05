using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Balloon : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject balloon;
	public Transform SharpCheck;
	public float SharpCheckRadius;
	public LayerMask WhatIsSharp;
	private bool touchSharp;
	
void Start() {
     rb = GetComponent<Rigidbody2D>();
}

    void FixedUpdate() {
         rb.velocity = new Vector2(rb.velocity.x, 5);
		 touchSharp = Physics2D.OverlapCircle(SharpCheck.position, SharpCheckRadius, WhatIsSharp); 
		 
		 if(touchSharp){
			 Destroy(gameObject);
         }
	}

}
