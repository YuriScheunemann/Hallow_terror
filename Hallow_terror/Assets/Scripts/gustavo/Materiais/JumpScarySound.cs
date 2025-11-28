using UnityEngine;

public class JumpScarySound : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}