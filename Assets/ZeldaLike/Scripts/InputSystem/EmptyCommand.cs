using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCommand : Command
{
    public override void Execute(){
        Debug.Log("This command is not defined");
    }
    public override void Undo(){
        Debug.Log("This command is not defined");
    }
    
}
