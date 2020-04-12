using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, AliveObject
{
    private KeyboardManagement commandSystem;
    public void Start()
    {
        commandSystem = new KeyboardManagement();
        commandSystem.setCommand(0, new Move(this));
        commandSystem.setCommand(1, new Attack(this));
        
    }

    public void Update()
    {
        
    }
    

    public void Move()
    {
            
    }

    public void Attack()
    {

    }
}
