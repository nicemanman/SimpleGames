using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeysControl
{
    private static KeyCode[] movementKeysList;
    private static KeyCode action;
    private static KeyCode attack;
    public static Dictionary<string, string> allKeys = new Dictionary<string, string>();
    static KeysControl(){
        movementKeysList = new KeyCode[]{KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
        action = KeyCode.F;
        attack = KeyCode.G;

        allKeys.Add("A/W/S/D", "Movement keys");
        allKeys.Add(action.ToString(), "Context action");
        allKeys.Add(attack.ToString(), "Attack!");
    }
    
    public static bool AWSDPressed(){
        foreach (KeyCode key in movementKeysList)
        if (Input.GetKey(key))
            return true;
        return false;
    }

    public static bool ActionKeyPressed()
    {
        if (Input.GetKeyDown(action)) return true;
        return false;
    }
    public static string GetActionKey(){
        return action.ToString();
    }
    public static bool AttackKeyPressed()
    {
        if (Input.GetKeyDown(attack)) return true;
        return false;
    }

}
