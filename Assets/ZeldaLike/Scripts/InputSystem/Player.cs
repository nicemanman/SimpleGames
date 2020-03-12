using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private Vector2 nextposition;
    public float speed;
    public KeyboardManagement commandSystem;
    private Rigidbody2D myRigidBody; 
    private Animator animator;
    
    void Start()
    {
        
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextposition = Vector2.zero;
        commandSystem.setCommand(0, new Move(this));
    }

    private void FixedUpdate() {
        StaySteel();
        if (KeysControl.AWSDPressed())
          commandSystem.Execute(0);
        
    }
    public void Move(){
        nextposition.x = Input.GetAxisRaw("Horizontal");
        nextposition.y = Input.GetAxisRaw("Vertical");
        myRigidBody.MovePosition((Vector2)transform.position + nextposition * speed * Time.deltaTime);
        animator.SetFloat("moveX",nextposition.x);
        animator.SetFloat("moveY",nextposition.y); 
        animator.SetBool("moving",true);
    }

    public void StaySteel(){
        animator.SetBool("moving",false);
        nextposition = Vector2.zero;
    }
    public void Attack(){}
    public void Talk(){}
    
    
}
