using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Command
{
    Player player;
    public Attack(Player player)
    {
        this.player = player;
    }
    public override void Execute()
    {
        player.Attack();
    }
    public override void Undo(){}
}
