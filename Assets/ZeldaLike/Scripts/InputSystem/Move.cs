using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
   AliveObject obj;
   
   public Move(AliveObject obj){
       this.obj = obj;  
   }
   public override void Execute(){
       obj.Move();
   }

   public override void Undo(){
       
   }
}
