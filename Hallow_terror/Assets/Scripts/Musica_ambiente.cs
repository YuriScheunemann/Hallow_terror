using UnityEngine;

public class Musica_ambiente : MonoBehaviour
{
    public AudioClip FundoTenso;
    private AudioSource audioNonoCifundoTensorcle;

    public AudioClip secondFundoTenso;
    private AudioSource audiosecondFundoTenso;

    public AudioClip fundoFlorest;
    private AudioSource audiosfundoFlorest;

    public float fundoFlorestVolume = 10f;
    public float FundoTensoFundoTensoVolume = 10f;
    public float secondFundoTensoVolume = 10f;

    void Start()
    {
        audioNonoCifundoTensorcle = gameObject.AddComponent<AudioSource>();

        audioNonoCifundoTensorcle.clip = FundoTenso;
        audioNonoCifundoTensorcle.loop = true;
        audioNonoCifundoTensorcle.volume = 10f;
        audioNonoCifundoTensorcle.Play();
        //--------------------------------------------------------------------------
        audioNonoCifundoTensorcle = gameObject.AddComponent<AudioSource>();
        audiosecondFundoTenso.clip = secondFundoTenso;
        audiosecondFundoTenso.loop = true;
        audiosecondFundoTenso.volume = 10f;
        audiosecondFundoTenso.Play();
        //--------------------------------------------------------------------------
        audioNonoCifundoTensorcle = gameObject.AddComponent<AudioSource>();
        audiosfundoFlorest.clip = fundoFlorest;
        audiosfundoFlorest.loop = true;
        audiosfundoFlorest.volume = 10f;
        audiosfundoFlorest.Play();
    }
}
