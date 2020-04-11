using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class MainMenu : MonoBehaviour
{

    public GameObject startButton;
    public GameObject quitButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        startButton.GetComponent<Button_UI>().ClickFunc = () => {
            SoundManager.play("click");
            Loader.Load(Loader.Scene.GameSelectionScene);
        };  
        quitButton.GetComponent<Button_UI>().ClickFunc = () => {
            SoundManager.play("click");
            Application.Quit();
        }; 

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
