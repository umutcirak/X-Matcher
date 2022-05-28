using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioClip matchClip;
    [SerializeField][Range(0,1f)] float matchClipCVolume;

   
    public void PlayMatchClip()
    {
        AudioSource.PlayClipAtPoint(matchClip, Camera.main.transform.position, matchClipCVolume);
    }
    

}
