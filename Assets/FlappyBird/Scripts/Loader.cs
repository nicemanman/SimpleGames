﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{ 
    public static Dictionary<int, Scene> games = new Dictionary<int, Scene>(); 
    public static int currentGame = 0;
    public enum Scene {FlappyBirdScene, GameSelectionScene, LoadingScene};
    private static Scene targetScene;
    
    
    public static void Load(Scene scene){
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
        targetScene = scene;        
    }

    public static void LoadTargetScene(){
        SceneManager.LoadScene(targetScene.ToString());
    }

    static Loader(){
        games.Add(0, Scene.FlappyBirdScene);
        
    }
}
