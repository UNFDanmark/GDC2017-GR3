using UnityEngine;
using UnityEngine.Audio;
using System.Collections;


public class AudioScript : MonoBehaviour
{


    //Lyd Klip Variable, kan indeholde et lydklip i sætter 
    public AudioClip Hit;
    public AudioClip Jump;
    public AudioClip Falling;
    //Definere Audio Source vi kalder den Audio(Husk at sætte den i inspector)
    public AudioSource Audio;
    public AudioSource Audio2;
    //Hop funktionen husk den skal vaere public
    public void HitSound()
    {
        Audio.clip = Hit;
        Audio.Play();
    }
    public void JumpSound()
    {
        Audio2.clip = Jump;
        Audio2.Play();
    }
    public void FallingSound()
    {
        Audio2.clip = Falling;
        Audio2.Play();
    }
}