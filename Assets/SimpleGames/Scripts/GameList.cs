using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameList : MonoBehaviour
{
    public static Dictionary<int, string> games = new Dictionary<int, string>(); 
    private static int currentGame = 0;
    void Start()
    {
        games.Add(0, "FlappyBirdScene");
        games.Add(1, "SimpleRPG");
        games.Add(2, "SimpleRPG");
        games.Add(3, "SimpleRPG");
        
    }

    public static void next(){
        if (games.Count > currentGame)
        currentGame++;
    }
    public static void prev(){
        if (currentGame > 0)
        currentGame--;
    }
    public static string getCurrent(){
        return games[currentGame];
    }
    public static string getCurrentIndex(){
        return currentGame.ToString();
    }
    
}
