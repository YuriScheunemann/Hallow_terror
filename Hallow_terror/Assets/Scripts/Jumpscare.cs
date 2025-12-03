using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public AudioClip Sound1;
    private AudioSource audioSound1;

    public AudioClip Sound2;
    private AudioSource audioSound2;

    public AudioClip Sound3;
    private AudioSource audioSound3;

    public float fundoFlorestVolume = 100f;
    public float FundoTensoFundoTensoVolume = 100f;
    public float secondFundoTensoVolume = 100f;

    void Start()
    {
        audioSound1 = gameObject.AddComponent<AudioSource>();

        audioSound1.clip = Sound1;        
        audioSound1.volume = 100f;
        audioSound1.Play();
        //--------------------------------------------------------------------------
        audioSound1 = gameObject.AddComponent<AudioSource>();
        audioSound2.clip = Sound2;
        audioSound2.volume = 100f;
        audioSound2.Play();
        //--------------------------------------------------------------------------
        audioSound1 = gameObject.AddComponent<AudioSource>();
        audioSound3.clip = Sound3;
        audioSound3.volume = 100f;
        audioSound3.Play();
    }
}