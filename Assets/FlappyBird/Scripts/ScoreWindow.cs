using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreWindow : MonoBehaviour
{
    private Text scoreText;
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Level.instance.GetScore().ToString();
    }
}
