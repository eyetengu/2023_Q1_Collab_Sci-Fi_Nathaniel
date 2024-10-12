using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleEvent : MonoBehaviour
{
    public ParticleSystem particleEffect;

    // This method will be called by the animation event
    public void PlayParticleEffect()
    {
        particleEffect.Play();

    }

    public void PauseParticleEffect()
    {
        particleEffect.Pause();
    }
}
