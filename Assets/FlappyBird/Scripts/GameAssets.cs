using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public float PIPE_DESTROY_X_POSITION  = -100f;
    public float PIPE_SPAWN_X_POSITION  = 100f;
    
    public float PIPE_MOVE_SPEED  = 100000f;
    public static GameAssets instance {get; private set;}
    public Sprite pipeHeadSprite;
    public Sprite ground;
    public Transform pfPipeHead;
    public Transform pfPipeBody;
    
    private void Awake() {
        instance = this;        
    }
}
