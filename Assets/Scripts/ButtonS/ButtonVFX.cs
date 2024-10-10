using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVFX : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public void OnClick()
    {
        if (particleSystem != null) particleSystem.Play();
    }
}
