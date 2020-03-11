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
    private KeyCode[] movementKeysList;
    void Start()
    {
        movementKeysList = movementKeys();
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextposition = new Vector2(0,0);
        commandSystem.setCommand(0, new Move(this));
    }

    private void Update() {
        StaySteel();
        if (areMovingKeysPressed())
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
    public KeyCode[] movementKeys(){
        return new KeyCode[]{KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
    }
    public bool areMovingKeysPressed(){
        foreach (KeyCode key in movementKeysList)
        if (Input.GetKey(key))
            return true;
        return false;
    }
    
}
