using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreWindow : MonoBehaviour
{
    [SerializeField]private Text scoreText;
    void Start()
    {
        scoreText = scoreText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Level.instance.GetScore().ToString();
    }
}
