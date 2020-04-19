using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZeldaGameManager : MonoBehaviour
{
    //Главный канвас с интерфейсом, если он активен - активна и игра
    public Window RootUICanvas;
    public static event Action BlockedRootCanvas;
    public static event Action UnblockedRootCanvas;
    
    public void Update()
    {
        if (!RootUICanvas.isActiveCanvas)
            BlockedRootCanvas?.Invoke();
        else
            UnblockedRootCanvas?.Invoke();
    }

}
