using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    
    
    public float x {get {return pipeBody.position.x;} private set{}}
    public float y {get {return pipeBody.position.y;} private set{}}
    
    private Transform pipeHead;
    private Transform pipeBody;

    public Pipe(Transform head, Transform body){
        pipeHead = head;
        pipeBody = body;    
    }
    
    public void Move(){
        pipeHead.position += new Vector3(-1,0) * GameAssets.instance.PIPE_MOVE_SPEED *Time.deltaTime;
        pipeBody.position += new Vector3(-1,0) * GameAssets.instance.PIPE_MOVE_SPEED *Time.deltaTime;

    }

    public void DestroySelf(){
        Destroy(pipeHead.gameObject);
        Destroy(pipeBody.gameObject);
        
    }

    
}
