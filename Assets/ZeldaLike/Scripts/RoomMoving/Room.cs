using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{   
    public string RoomName;
    public GameObject RoomScene;
    public int height, width;
    public void createRoom(Vector2 srcpos)
    {
        Instantiate(RoomScene, new Vector3(srcpos.x, srcpos.y + height,0),RoomScene.transform.rotation);
    }

    
    
}
