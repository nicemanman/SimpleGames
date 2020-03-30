using System.Collections;
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
    //text box for actions
    public GameObject ContextActionsBox;
    public Text ContextActionsTextObj; 
    //text box for dialogs
    public GameObject DialogBox;
    public Text DialogBoxTextObj; 
    
    public bool isAttacking = false;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        nextposition = Vector2.zero;
        commandSystem.setCommand(0, new Move(this));
        commandSystem.setCommand(1, new ContextAction(this));
        commandSystem.setCommand(2, new Attack(this));
    }

    private void FixedUpdate() {
        StaySteel();
        if (KeysControl.AWSDPressed())
            commandSystem.Execute(0);
        else if (KeysControl.ActionKeyPressed())
            commandSystem.Execute(1);
        else if (KeysControl.AttackKeyPressed())
            commandSystem.Execute(2);
        
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
        ContextActionsBox?.SetActive(false);
        DialogBoxTextObj.text = ""; 
        StopCoroutine(ReadableObject.Read(DialogBoxTextObj));  
    }
    
    public void StaySteel(){
        animator.SetBool("moving"   , false);
        nextposition = Vector2.zero;
    }
    public void Attack()
    {
        if (!isAttacking)
        StartCoroutine(AttackingProcess());
    }
    private IEnumerator AttackingProcess()
    {
        animator.SetBool("attacking", true);
        isAttacking = true;
        Debug.Log("Attack");
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        isAttacking = false;
    }
    public void Talk(){}
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Readable"))
        {
            ReadableObject = other.GetComponent<Readable>();
            currentAction = Read;
            ContextActionsBox?.SetActive(true);
            ContextActionsTextObj.text = $"{KeysControl.GetActionKey()} - read";
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
