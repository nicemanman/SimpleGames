﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Vector2 nextposition;
    public float speed;
    public KeyboardManagement commandSystem;
    private Rigidbody2D myRigidBody; 
    private Animator animator;
    //different actions - read, lift up, throw out, talk...
    private Readable ReadableObject;
    private delegate void action();
    private action currentAction;
    
    [InspectorName("Dialog box")]
    public GameObject DialogBox;
    public Text DialogBoxTextObj; 
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextposition = Vector2.zero;
        commandSystem.setCommand(0, new Move(this));
        commandSystem.setCommand(1, new ContextAction(this));
        
    }

    private void FixedUpdate() {
        StaySteel();
        if (KeysControl.AWSDPressed())
            commandSystem.Execute(0);
        else if (KeysControl.ActionKeyPressed())
            commandSystem.Execute(1);
        
    }
    public void Move()
    {
        nextposition.x = Input.GetAxisRaw("Horizontal");
        nextposition.y = Input.GetAxisRaw("Vertical");
        myRigidBody.MovePosition((Vector2)transform.position + nextposition * speed * Time.deltaTime);
        animator.SetFloat("moveX",nextposition.x);
        animator.SetFloat("moveY",nextposition.y); 
        animator.SetBool("moving",true);
    }

    public void DoAction()
    {
        currentAction?.Invoke();
    }

    public void Read()
    {
        DialogBox?.SetActive(true);
        DialogBoxTextObj.text = "";
        StartCoroutine(ReadableObject.Read(DialogBoxTextObj));
    }

    public void ReadClose(){
        DialogBox?.SetActive(false); 
        DialogBoxTextObj.text = ""; 
        StopCoroutine(ReadableObject.Read(DialogBoxTextObj));  
    
    }

    
    public void StaySteel(){
        animator.SetBool("moving",false);
        nextposition = Vector2.zero;
    }
    public void Attack(){}
    public void Talk(){}
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Readable"))
        {
            ReadableObject = other.GetComponent<Readable>();
            currentAction = Read;
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {      
            if (other.CompareTag("Readable"))
            {
                commandSystem.Undo(1);
                ReadableObject = null;
                currentAction = null;  
            } 
    }
}
