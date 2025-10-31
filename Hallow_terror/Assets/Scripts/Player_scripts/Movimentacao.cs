using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class Movimentacao : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;

    private Rigidbody rb;
   
    private float horizontalInput;
    private float verticalInput;
    void Start()
    {
        rb = GetComponent<Rigidbody>();       
        rb.freezeRotation = true;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 moveDirection = transform.forward * verticalInput * moveSpeed;
        rb.linearVelocity = new Vector3(moveDirection.x, rb.linearVelocity.y, moveDirection.z);        
      
    }
    void Rotate()
    {
        // Gira o personagem com A/D
        float rotation = horizontalInput * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, rotation, 0);
    }





    /*
    public Rigidbody rb;
    public Animator anim;
    public float moveSpeed = 20.0f;
    Vector3 movement;

    
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        movement = new Vector3(xAxis, 0, zAxis) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);      


        if (movement.x != 0 || movement.z != 0)
        {

            anim.SetBool("Run", true);

        }
        else
        {
            anim.SetBool("Run", false);

        }

        if (xAxis == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90, 0), moveSpeed);
        }

        if (xAxis == -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90, 0), Time.deltaTime * moveSpeed);
        }

        if (zAxis == 1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * moveSpeed);
        }


        if (zAxis == -1)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * moveSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
       
        if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * 3, ForceMode.Impulse);
        }
    }*/
}