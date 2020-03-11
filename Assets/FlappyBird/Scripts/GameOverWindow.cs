using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
public class GameOverWindow : MonoBehaviour
{
    private Text scoreText;

    private void Awake() {
        
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        transform.Find("RetryButton").GetComponent<Button_UI>().ClickFunc = () => {
            Loader.Load(GameList.getCurrent());
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
        gameObject.SetActive(false);
    }

    private void Show(){
        gameObject.SetActive(true);
    }
}
