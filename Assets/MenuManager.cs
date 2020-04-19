using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Sprite[] backgrounds = new Sprite[4];
    public GameObject[] clouds = new GameObject[5];
    public GameObject threshold;
    public SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr.sprite = backgrounds[Random.Range(0,3)];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].transform.Translate(Random.Range(-10,-1)*Time.deltaTime,0,0);
            if (clouds[i].transform.position.x < threshold.transform.position.x)
            {                
                var cloud = Instantiate(clouds[i], new Vector3(-threshold.transform.position.x, 
                                    Random.Range(51f,1f), 0), Quaternion.identity);
                Destroy(clouds[i]);
                clouds[i] = cloud;
            }
        }
    }
}
