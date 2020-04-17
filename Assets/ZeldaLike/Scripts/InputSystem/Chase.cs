using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Command
{
    Enemy pursuer;
    GameObject pursued;
    
    public Chase(Enemy pursuer, GameObject pursued)
    {
        this.pursuer = pursuer;
        this.pursued = pursued;
    }
    public override void Execute()
    {
        pursuer.Chase(pursued);
    }
    public override void Undo(){}
}
