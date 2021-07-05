///////////////////////////////////////////////////////////////////////
//
//      AudioEffects.cs
//声效控制
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;
using System.Collections;

// Allows for audio source manipulations like fadeIn/fadeOut
public static class AudioEffects
{
    // Fades the audio source from 'from' volume to 'to' volume in a 'fadeTime' amount of time 调整声音大小
    public static IEnumerator Fade(AudioSource audioSource, float from, float to, float fadeTime)
    {
      
        // For now just instantly sets to the 'to' volume
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (to < Mathf.Epsilon)
        {
            audioSource.Pause();
        }

        audioSource.volume = to;
        
        yield return null;
    }
}
