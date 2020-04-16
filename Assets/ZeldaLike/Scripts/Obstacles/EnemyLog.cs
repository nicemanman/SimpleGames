using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLog : Enemy
{
    // Start is called before the first frame update
    private Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  
    }

    private void Update() {
        DetectPlayer();    
    }
    public override void Attack(){}

    public override void Move(){}

    public override void DetectPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) >= attackRadius)  
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

}
