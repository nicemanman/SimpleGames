using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey.Utils;
public class ChooseGameScript : MonoBehaviour
{
    
    void Awake()
    {
        Loader.InitGames();
        transform.Find("Start").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.games[Loader.currentGame]);
        };  
        transform.Find("Quit").GetComponent<Button_UI>().ClickFunc = () => {
            Application.Quit();
        };  
    }

    
}
