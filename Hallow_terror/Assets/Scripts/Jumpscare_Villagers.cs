using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Jumpscare_Villagers : MonoBehaviour
{
    public AudioClip[] Espancamento;
    private AudioSource audioespancamento;
    public AudioClip MusicaFundo;
    private AudioSource audioMusica;
    public AudioClip Onetime;
    private AudioSource audioOnetimeto;

    [Range(0f, 1f)]
    public float volume = 1f;

    void Start()
    {
        audioespancamento = gameObject.AddComponent<AudioSource>();
        audioespancamento.volume = volume;
        StartCoroutine(TocarTodos());

        audioMusica = gameObject.AddComponent<AudioSource>();

        audioMusica.clip = MusicaFundo;
        audioMusica.loop = true;
        audioMusica.volume = 100f;
        audioMusica.Play();

        audioOnetimeto = gameObject.AddComponent<AudioSource>();

        audioOnetimeto.clip = Onetime;
        audioOnetimeto.loop = false;
        audioOnetimeto.volume = 100f;
        audioOnetimeto.Play();


    }

    IEnumerator TocarTodos()
    {
        foreach (AudioClip clip in Espancamento)
        {
            audioespancamento.clip = clip;
            audioespancamento.Play();
            yield return new WaitForSeconds(clip.length);
        }


    }
}
