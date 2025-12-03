using UnityEngine;

public class Susto : MonoBehaviour
{
    public AudioClip clipSusto;
    private AudioSource audioSusto;
    void Start()
    {
        audioSusto = gameObject.AddComponent<AudioSource>();

        audioSusto.clip = clipSusto;        
        audioSusto.volume = 100f;        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSusto.PlayOneShot(clipSusto);
        }
    }
}
