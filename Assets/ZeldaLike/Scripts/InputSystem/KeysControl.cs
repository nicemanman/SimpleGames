using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeysControl
{
    private static KeyCode[] movementKeysList;
    private static KeyCode talk;
    private static KeyCode attack;
    
    static KeysControl(){
        movementKeysList = new KeyCode[]{KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
    }
    
    public static bool AWSDPressed(){
        foreach (KeyCode key in movementKeysList)
        if (Input.GetKey(key))
            return true;
        return false;
    }
}
