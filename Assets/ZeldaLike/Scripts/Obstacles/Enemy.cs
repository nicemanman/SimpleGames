using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, AliveObject
{
    protected KeyboardManagement commandSystem;
    public int health = 100;
    public string enemyName;
    public int baseAttack = 10;
    public float moveSpeed;
    private void Start()
    {
        commandSystem = new KeyboardManagement();
        commandSystem.setCommand(0, new Move(this));
        commandSystem.setCommand(1, new Attack(this));
    }

    
    public abstract void Move();

    public abstract void Attack();

    public abstract void DetectPlayer();
}
