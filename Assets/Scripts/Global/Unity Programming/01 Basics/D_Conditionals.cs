using UnityEngine;

public class D_Conditionals : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;

    private Rigidbody _rb;
    private bool _isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        _rb.AddForce(movement * speed);

        // Saltar
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Cambiar estado del personaje
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeState(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeState(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeState(3);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    void ChangeState(int state)
    {
        switch (state)
        {
            case 1:
                Debug.Log("Estado 1: Caminando");
                // Lógica para el estado de caminar
                break;
            case 2:
                Debug.Log("Estado 2: Corriendo");
                // Lógica para el estado de correr
                break;
            case 3:
                Debug.Log("Estado 3: Saltando");
                // Lógica para el estado de saltar
                break;
            default:
                Debug.Log("Estado desconocido");
                break;
        }
    }
}
