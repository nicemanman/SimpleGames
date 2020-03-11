using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using CodeMonkey.Utils;
using UnityEngine.UI;
public class ChooseGameScript : MonoBehaviour
{
    [SerializeField]private Text countText;
    [SerializeField]private GameObject LeftArrow;
    [SerializeField]private GameObject RightArrow;
    [SerializeField]private GameObject StartButton;
    
    void Awake()
    {
        countText.text = GameList.getCurrentIndex();
        LeftArrow.GetComponent<Button_UI>().ClickFunc = () => {
            GameList.prev();
            countText.text = GameList.getCurrentIndex();
        };  
        RightArrow.GetComponent<Button_UI>().ClickFunc = () => {
            GameList.next();
            countText.text = GameList.getCurrentIndex();
        };  
        StartButton.GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(GameList.getCurrent());
        };
        
        
    }

    
}
