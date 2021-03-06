﻿using System.Collections;
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
    [SerializeField]private GameObject BackButton;
    [SerializeField] private Image GamePreview;
    [SerializeField] private GameList GameList;

    void Awake()
    {
        GamePreview.sprite = GameList.getCurrent();
        LeftArrow.GetComponent<Button_UI>().ClickFunc = () => {
            SoundManager.play("click");
            GameList.prev();
            GamePreview.sprite = GameList.getCurrent();
        };  
        RightArrow.GetComponent<Button_UI>().ClickFunc = () => {
            SoundManager.play("click");
            GameList.next();
            GamePreview.sprite = GameList.getCurrent();
        };  
        StartButton.GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(GameList.getCurrentSceneName());
        };
        BackButton.GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load("MainMenu");
        };
        
        
    }

    
}
