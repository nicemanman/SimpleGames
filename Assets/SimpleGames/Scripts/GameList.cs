using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameList : MonoBehaviour
{
    
    private int currentGame = 0;
    public Game[] gamesArray;
    void Start()
    {
          
    }

    public void next(){
        if (gamesArray.Length > currentGame + 1)
            currentGame++;
        else
            currentGame = 0;
    }
    public void prev(){
        if (currentGame > 0)
            currentGame--;
        else
            currentGame = gamesArray.Length - 1;
    }
    public Sprite getCurrent(){
        try
        {
            return gamesArray[currentGame].sprite;
        }
        catch 
        {
            throw new System.ArgumentNullException(nameof(currentGame) + " _ " +currentGame);
        }
        
    }

    public string getCurrentSceneName(){
        return gamesArray[currentGame].sceneName;
    }
    
}
