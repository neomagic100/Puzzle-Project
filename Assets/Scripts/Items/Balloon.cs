using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Matthew Sanders
// script for the balloon item. The balloon will pop once it touches the dart which has the tag "sharp"


public class Balloon : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject balloon;
	private Animator myBalloon;
	private AudioSource popSound;
	private bool audioPlaying;		// this is used so that the popping sound only plays once
	
void Start() {
     rb = GetComponent<Rigidbody2D>();
	 myBalloon = GetComponent<Animator>();
	 popSound = GetComponent<AudioSource>();
	 audioPlaying = false;
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
    {
        // If a collision is detected with an Item
        if (collision.gameObject.CompareTag("sharp"))
        {
			myBalloon.Play("balloonPop");
			 if(audioPlaying == false){
				 popSound.Play();
			 }
			 audioPlaying = true;
			 Destroy(gameObject, 0.08f);
        }
    }
	

}
