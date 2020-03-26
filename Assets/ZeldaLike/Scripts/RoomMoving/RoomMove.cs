using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cam;
    public bool needLocationName = false;
    //very bad way. I know it. 
    public string locationName;
    public GameObject text;
    public Text locationNameText;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            other.transform.position += playerChange;
            if (needLocationName)
            {
                StartCoroutine(PlaceLocationName());
            }
        } 
    }

    private IEnumerator PlaceLocationName()
    {
        text.SetActive(true);
        locationNameText.text = locationName;
        yield return new WaitForSeconds(1f);
        text.SetActive(false);
    }
}
