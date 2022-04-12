using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Matthew Sanders
// script for the balloon item. The balloon will pop once it touches the dart which has the tag "sharp"


public class Balloon : Item
{
	public Rigidbody2D rb;
	public GameObject balloon;
	public Transform SharpCheck;
	public float SharpCheckRadius;
	public LayerMask WhatIsSharp;
	private bool touchSharp;
	private Animator myBalloon;
	private AudioSource popSound;
	private bool audioPlaying;		// this is used so that the popping sound only plays once
	
void Start() {
     rb = GetComponent<Rigidbody2D>();
	 myBalloon = GetComponent<Animator>();
	 popSound = GetComponent<AudioSource>();
	 audioPlaying = false;
	}

    void FixedUpdate() {
		 touchSharp = Physics2D.OverlapCircle(SharpCheck.position, SharpCheckRadius, WhatIsSharp);
		 if(touchSharp){
			 myBalloon.Play("balloonPop");
			 if(audioPlaying == false){
				 popSound.Play();
			 }
			 audioPlaying = true;
			 Destroy(gameObject, 0.5f);
		 }
	}
	

}
