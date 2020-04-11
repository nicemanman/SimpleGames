using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (AudioSource))]
public class SoundManager : MonoBehaviour
{
    
    private AudioSource audioSource;
    public static SoundManager instance {get; private set;}
    public enum sounds {jump, die, score, click} ;
    public SoundAudioClip[] audioClips;
    void Awake()
    {
        instance = this;
        //Получить источник звука из текущего game object
        audioSource = GetComponent<AudioSource>();      
    }
    public static void play(string soundName){
        instance.PlaySound(soundName);
    }
    private void PlaySound(string soundName){  
       audioSource.clip = GetSound(soundName);
       audioSource.PlayOneShot(audioSource.clip); 
    }

    private AudioClip GetSound(string soundName){
        
        foreach (SoundAudioClip s in audioClips){
            if (s.sound.ToString() == soundName)
            return s.clip;
        }
        return null;
    }
    [System.Serializable]
    public class SoundAudioClip{
       public AudioClip clip;
       public sounds sound; 
    }
}
