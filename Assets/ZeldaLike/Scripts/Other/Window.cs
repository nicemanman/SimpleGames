using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
public class Window : MonoBehaviour
{
    public Settings[] settingsList;
    
    private Window windowObject;
    //Если canvas активный - вы можете нажимать клавиши на нем
    public bool isActiveCanvas = true;
    public bool isRootCanvas = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Settings s in settingsList)
        {
            var button = s.button;
            s.button.ClickFunc = () => 
            {
                var window = s.window;
                windowObject = window.GetComponent<Window>();
                if (isActiveCanvas)
                {
                    if (button.type == ButtonType.OpenWindow)
                    {
                        window.SetActive(true);
                    }
                    else if (button.type == ButtonType.CloseWindow)
                    {
                        this.gameObject.SetActive(false); 
                    }
                    else if (button.type == ButtonType.Quit)
                    {
                        Loader.Load("MainMenu");
                    }
                    windowObject.isActiveCanvas = true;
                    isActiveCanvas = false;
                }
            };
        }
    }

    [System.Serializable]
    public class Settings
    {
        public Button_UI button;
        //Это окно, которое надо сделать activeCanvas по нажатию.
        public GameObject window;
    }
}
