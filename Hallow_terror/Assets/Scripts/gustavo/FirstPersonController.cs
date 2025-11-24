using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour
{
    [Header("Velocidade")]
    public float walkSpeed = 5f;
    public float runSpeed = 9f;

    [Header("Mouse")]
    public float mouseSensitivity = 2f;
    public Transform playerCamera; // arraste a câmera filha aqui
    public float maxLookAngle = 85f;

    CharacterController controller;
    float xRotation = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (playerCamera == null)
            Debug.LogWarning("PlayerMovementFPS: arraste a câmera para 'playerCamera' no Inspector.");

        // Trava cursor para teste; pressione ESC para liberar (você pode alterar conforme precisar)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        if (playerCamera != null)
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float x = Input.GetAxis("Horizontal"); // A/D, esquerda/direita
        float z = Input.GetAxis("Vertical");   // W/S, frente/tras

        Vector3 move = transform.right * x + transform.forward * z;
        // SimpleMove aplica gravidade automaticamente e já considera deltaTime
        controller.SimpleMove(move.normalized * speed);
    }
}