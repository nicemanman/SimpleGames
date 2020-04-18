using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyLog : Enemy
{
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

        commandSystem = new KeyboardManagement();
        commandSystem.setCommand(0, new Move(this));
        commandSystem.setCommand(1, new Attack(this));
        commandSystem.setCommand(2, new Chase(this, target));
    }

    private void Update() {
        
        DetectPlayer();  
    }
    public override void Attack(){}

    public override void Move()
    {
        //patroling, for ex
    }

    public override void Chase(GameObject target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    public override void DetectPlayer()
    {
        bool playerDetected = Vector3.Distance(target.transform.position, transform.position) <= chaseRadius
                         && Vector3.Distance(target.transform.position, transform.position) >= attackRadius;
        if (playerDetected) commandSystem.Execute(2);
    }

    
    
}
