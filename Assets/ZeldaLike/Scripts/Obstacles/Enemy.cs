using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class Enemy : MonoBehaviour, AliveObject
{
    protected KeyboardManagement commandSystem;
    protected GameObject target;

    public int health = 100;
    public string enemyName;
    public int baseAttack = 10;
    public float moveSpeed;
    public bool paused;
    public Enemy()
    {
        ZeldaGameManager.BlockedRootCanvas += BlockMoving;
        ZeldaGameManager.UnblockedRootCanvas += UnblockMoving;
    }

    public void BlockMoving()
    {
        paused = true;
    }

    public void UnblockMoving()
    {
        paused = false;
    }

    public abstract void Move();

    public abstract void Attack();

    public abstract void Chase(GameObject pursued);
    public abstract void DetectPlayer();
}
