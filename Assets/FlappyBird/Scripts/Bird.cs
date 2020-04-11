using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using UnityEngine.UI;
[RequireComponent (typeof (Rigidbody2D))]
public class Bird : MonoBehaviour
{
    public float JUMP_AMOUNT = 100.0f;
    public event EventHandler OnDied;
    public event EventHandler OnStart;
    
    public static Bird instance {get; private set;}
    private Rigidbody2D birdRigidBody2D;
    private Collider2D birdCollider2D;
    private enum State{WAITING, PLAYING, DEAD}
    private State state;
    void Awake()
    {
        instance = this;
        birdRigidBody2D = GetComponent<Rigidbody2D>();
        birdCollider2D = GetComponent<Collider2D>();
        birdRigidBody2D.bodyType = RigidbodyType2D.Static;
        state = State.WAITING;
    }
    
    // Update is called once per frame
    private void Update()
    {   switch (state){
            case State.WAITING: 
                
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                    birdRigidBody2D.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    state = State.PLAYING;
                    OnStart?.Invoke(this, EventArgs.Empty);
                }
                
                break;
            case State.PLAYING: 
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
                Jump();
                }
                break;
            case State.DEAD: 
                OnDied?.Invoke(this, EventArgs.Empty);
                break;
            
        }
        
    }

    private void Jump(){
        birdRigidBody2D.velocity = Vector2.up * JUMP_AMOUNT;
        SoundManager.play("jump");
    }

    private void OnTriggerEnter2D(Collider2D other) { 
        birdCollider2D.enabled = false;
        state = State.DEAD;
        SoundManager.play("die");
    }
}
