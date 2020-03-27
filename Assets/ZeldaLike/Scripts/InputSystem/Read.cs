using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Read : Command
{
    private Player player;
    public Read(Player player)
    {
        this.player = player;
    }
    public override void Execute()
    {
        player.Read();
    }
    public override void Undo(){}
    
}
