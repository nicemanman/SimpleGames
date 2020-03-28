using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour, Readable
{    
    [SerializeField] private string text;
    [SerializeField] private string description;
    private void Awake() {
        tag = "Readable";    
    }
    public IEnumerator Read(Text textobj)
    {
        for (int i = 0; i < text.Length; i++)
        {
            textobj.text = text.Substring(0,i);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
