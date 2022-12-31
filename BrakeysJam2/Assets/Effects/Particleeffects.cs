
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Particleeffects
{
    public string name;

    public ParticleSystem effect;

    [HideInInspector]
    public ParticleSystem source;

}