using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllKeysPanel : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        WriteAllKeys();
    }

    public void  WriteAllKeys()
    {
        var dict = KeysControl.allKeys;
        foreach (KeyValuePair<string,string> key in dict)
        {
            text.text += $"{key.Key} -  {key.Value} \n";
        }
    }
}
