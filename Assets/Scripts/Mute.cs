using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mute : MonoBehaviour
{
    private bool isMuted = false;
    public Image mutedImage;
    
    public void MuteSong()
    {
        if (isMuted)
        {
            AudioListener.pause = false;
            isMuted = false;
            mutedImage.enabled = false;
        }
        else
        {
            AudioListener.pause = true;
            isMuted = true;
            mutedImage.enabled = true;
        }
    }
}
