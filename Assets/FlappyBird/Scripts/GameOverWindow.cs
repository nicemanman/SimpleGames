using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{ 
    private Text scoreText;
    public string thisSceneName;

    private void Awake() {
        
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(thisSceneName);
        };    
        
        
    }
    

    private void Start()
    {
        Bird.instance.OnDied += Bird_OnDiedOver;
        Hide();
    }

    private void Bird_OnDiedOver(object sender, System.EventArgs e){
        scoreText.text = Level.instance.GetScore().ToString(); 
        Show();   
    }

    private void Hide(){
        if (!gameObject.activeSelf)
        gameObject.SetActive(false);
    }

    private void Show(){
        gameObject.SetActive(true);
    }
}
