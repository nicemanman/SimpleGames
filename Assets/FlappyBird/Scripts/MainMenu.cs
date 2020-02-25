using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.Find("Start").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(Loader.Scene.GameScene);
        };  
        transform.Find("Quit").GetComponent<Button_UI>().ClickFunc = () => {
            Application.Quit();
        };  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
