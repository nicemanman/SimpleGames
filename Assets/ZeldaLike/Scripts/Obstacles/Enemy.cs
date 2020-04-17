using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Enemy : MonoBehaviour, AliveObject
{
    protected KeyboardManagement commandSystem;
    protected GameObject target;
    protected Transform targetTransform;
    protected Vector3 targetPosition;
    protected Vector3 myPosition;

    public int health = 100;
    public string enemyName;
    public int baseAttack = 10;
    public float moveSpeed;
    
   
    
    public abstract void Move();

    public abstract void Attack();

    public abstract void Chase(GameObject pursued);
    public abstract void DetectPlayer();
}
