using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command
{
   Player player;
   
   public Move(Player player){
       this.player = player;  
   }
   public override void Execute(){
       player.Move();
   }

   public override void Undo(){
       
   }
}
