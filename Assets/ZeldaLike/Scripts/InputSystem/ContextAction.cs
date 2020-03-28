using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextAction : Command
{
    private Player player;
    public ContextAction(Player player)
    {
        this.player = player;
    }
    public override void Execute()
    {
        player.DoAction();
    }
    public override void Undo()
    {
        player.ReadClose();
    }
    
}
