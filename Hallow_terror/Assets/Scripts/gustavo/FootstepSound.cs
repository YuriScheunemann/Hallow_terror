using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FootstepSound : MonoBehaviour
{
    public AudioSource walkSource;
    public AudioSource runSource;

    public float walkStepInterval = 0.5f;
    public float runStepInterval = 0.35f;

    CharacterController controller;
    float stepTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isWalking = (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                         && !Input.GetKey(KeyCode.LeftShift);

        bool isRunning = Input.GetKey(KeyCode.LeftShift)
                         && Input.GetAxisRaw("Vertical") > 0; // precisa andar pra frente

        // WALKING
        if (isWalking && controller.isGrounded)
        {
            PlayStep(walkSource, walkStepInterval);
        }
        else if (walkSource.isPlaying)
        {
            walkSource.Stop();
        }

        // RUNNING
        if (isRunning && controller.isGrounded)
        {
            PlayStep(runSource, runStepInterval);
        }
        else if (runSource.isPlaying)
        {
            runSource.Stop();
        }
    }

    void PlayStep(AudioSource src, float interval)
    {
        stepTimer -= Time.deltaTime;

        if (stepTimer <= 0f)
        {
            if (!src.isPlaying)
                src.Play();

            stepTimer = interval;
        }
    }
}