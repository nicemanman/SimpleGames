using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class Window : MonoBehaviour
{

    public Button_UI button1;
    public GameObject window;
    private Window windowObject;
    public bool isActiveCanvas = true;
    public bool isRootCanvas = false;
    // Start is called before the first frame update
    void Start()
    {
        windowObject = window.GetComponent<Window>();
        if (button1.type == ButtonType.OpenWindow)
        button1.ClickFunc = () => {
            if (isActiveCanvas)
            {
                window.SetActive(true);
                isActiveCanvas = false;
                windowObject.isActiveCanvas = true;
                
            }
            };
        else
        button1.ClickFunc = () => {
            if (isActiveCanvas)
            {
                gameObject.SetActive(false);
                windowObject.isActiveCanvas = true;
                isActiveCanvas = false;
            }
            };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
