using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    private Vector2 nextposition;
    public float speed;
    public KeyboardManagement commandSystem;
    
    private Rigidbody2D myRigidBody; 
    private KeyCode[] movementKeysList;
    void Start()
    {
        movementKeysList = movementKeys();
        myRigidBody = GetComponent<Rigidbody2D>();
        nextposition = new Vector2(0,0);
        commandSystem.setCommand(0, new Move(this));
    }

    private void Update() {
        
        nextposition = Vector2.zero;
        foreach (KeyCode key in movementKeysList)
        if (Input.GetKey(key))
            commandSystem.Execute(0);
    }
    public void Move(){
        nextposition.x = Input.GetAxisRaw("Horizontal");
        nextposition.y = Input.GetAxisRaw("Vertical");
        myRigidBody.MovePosition((Vector2)transform.position + nextposition * speed * Time.deltaTime);
    }

    public KeyCode[] movementKeys(){
        return new KeyCode[]{KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
    }
    //other operations
}
