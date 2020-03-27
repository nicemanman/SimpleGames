using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomTransfer : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;

    public GameObject text;
    public Text locationNameText;
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }
    public Room src;
    public Room dst;
    private Room temp;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")){
            temp = src;
            src = dst;
            dst = temp;

            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;

            cameraChange = -cameraChange;
            playerChange = -playerChange;
            
            StartCoroutine(PlaceLocationName());
        }
    }

    private IEnumerator PlaceLocationName()
    {
        text.SetActive(true);
        locationNameText.text = dst.RoomName;
        yield return new WaitForSeconds(1f);
        text.SetActive(false);
    }
}
