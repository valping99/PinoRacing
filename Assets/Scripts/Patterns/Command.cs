using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>  
/// Abstract class parent
/// </summary>
public abstract class Command
{
    // Play sound
    public abstract void Execute(AudioSource source, AudioClip audioClip, float volume);

    public virtual void Hit(AudioSource source, AudioClip audioClip, float voulume) { }
    public virtual void Loop(AudioSource source, AudioClip audioClip, float volume) { }
    public virtual void Stop(AudioSource source) { }
}

/// <summary>  
/// Abstract class child about play sound, stop sound, play loop sound
/// </summary>
public class PlaySound : Command
{
    public override void Execute(AudioSource source, AudioClip audioClip, float volume)
    {
        // Get sound
        Hit(source, audioClip, volume);
    }

    public override void Hit(AudioSource source, AudioClip audioClip, float volume)
    {
        // Play sound
        source.PlayOneShot(audioClip, volume);
    }
}

public class StopSound : Command
{
    public override void Execute(AudioSource source, AudioClip audioClip, float volume)
    {
        // Get sound
        Stop(source);
    }
    public override void Stop(AudioSource source)
    {
        // Stop sound
        source.Stop();
    }
}

public class PlayLoopSound : Command{
    public override void Execute(AudioSource source, AudioClip audioClip, float volume)
    {
        // Get sound
        Loop(source, audioClip, volume);
    }

    public override void Loop(AudioSource source, AudioClip audioClip, float volume)
    {
        // Play sound
        source.loop = true;
        source.clip = audioClip;
        source.volume = volume;
        source.Play();
    }
}