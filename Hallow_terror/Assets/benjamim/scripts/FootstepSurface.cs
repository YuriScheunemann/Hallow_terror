using UnityEngine;

public class FootstepSurface : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip madeiraSom;
    public AudioClip gramaSom;
    public float passoIntervalo = 0.4f;

    private string superficieAtual = "Default";
    private float timer;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.velocity.magnitude > 0.2f && controller.isGrounded)
        {
            timer += Time.deltaTime;
            if (timer >= passoIntervalo)
            {
                TocarSom();
                timer = 0f;
            }
        }
        else
        {
            timer = passoIntervalo;
        }
    }

    void TocarSom()
    {
        switch (superficieAtual)
        {
            case "Madeira":
                audioSource.PlayOneShot(madeiraSom);
                break;
            case "Grama":
                audioSource.PlayOneShot(gramaSom);
                break;
            default:
                audioSource.PlayOneShot(gramaSom);
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        superficieAtual = other.tag;
    }

    void OnTriggerStay(Collider other)
    {
        superficieAtual = other.tag;
    }
}
