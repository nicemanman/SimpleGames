using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeysControl
{
    private static KeyCode[] movementKeysList;
    private static KeyCode action;
    private static KeyCode attack;
    public static Dictionary<string, string> allKeys = new Dictionary<string, string>();
    public static bool KeysBlocked = false;
    static KeysControl(){
        movementKeysList = new KeyCode[]{KeyCode.A, KeyCode.W, KeyCode.S, KeyCode.D};
        action = KeyCode.F;
        attack = KeyCode.G;
        ZeldaGameManager.BlockedRootCanvas += BlockKeys;
        ZeldaGameManager.UnblockedRootCanvas += UnblockKeys;
        
        allKeys.Add("A/W/S/D", "Movement keys");
        allKeys.Add(action.ToString(), "Context action");
        allKeys.Add(attack.ToString(), "Attack!");
    }
    
    private static void BlockKeys(){
        KeysBlocked = true;
    }

    private static void UnblockKeys(){
        KeysBlocked = false;
    }

    public static bool AWSDPressed(){
        if (!KeysBlocked)
        foreach (KeyCode key in movementKeysList)
        if (Input.GetKey(key))
            return true;
        return false;
    }

    public static bool ActionKeyPressed()
    {
        if (!KeysBlocked && Input.GetKeyDown(action)) return true;
        return false;
    }
    public static string GetActionKey(){
        return action.ToString();
    }
    public static bool AttackKeyPressed()
    {
        if (!KeysBlocked && Input.GetKeyDown(attack)) return true;
        return false;
    }

}
