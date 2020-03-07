using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof (AudioSource))]
public class BirdSoundManager : MonoBehaviour
{
    
    private AudioSource audioSource;
    public static BirdSoundManager instance {get; private set;}
    public enum sounds {jump, die, score} ;
    public SoundAudioClip[] audioClips;
    void Awake()
    {
        instance = this;
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
