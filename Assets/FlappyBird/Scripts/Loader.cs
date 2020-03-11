using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class Loader
{ 
    
    
    public enum Scene {GameSelectionScene, LoadingScene};
    private static Scene targetScene;
    
    
    public static void Load(Scene scene){
        try{
            SceneManager.LoadScene(Scene.LoadingScene.ToString());
        }
        catch(UnityException){}
        targetScene = scene;        
    }

    public static void LoadTargetScene(){
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static void Load(string name){
        SceneManager.LoadScene(name);
    }

}
