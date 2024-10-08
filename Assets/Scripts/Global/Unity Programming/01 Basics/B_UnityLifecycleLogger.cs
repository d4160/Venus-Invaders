using UnityEngine;

/// <summary>
/// https://docs.unity3d.com/Manual/ExecutionOrder.html
/// </summary>

public class B_UnityLifecycleLogger : MonoBehaviour
{
    public float speed = 2;
    public float detectionRayLength = 1.5f;

    private Rigidbody2D _rb2D;

    #region Script Lifecycle
    void Awake()
    {
        // Se llama cuando el script de la instancia se está cargando.
        Debug.Log(gameObject.name + " - Awake");
        _rb2D = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        // Se llama cuando el objeto se habilita.
        Debug.Log(gameObject.name + " - OnEnable");
    }

    void Start()
    {
        // Se llama antes de la primera actualización del frame.
        Debug.Log(gameObject.name + " - Start");
    }

    void Update()
    {
        // Se llama una vez por frame.
        Debug.Log(gameObject.name + " - Update");
    }

    void LateUpdate()
    {
        // Se llama una vez por frame, después de todas las actualizaciones.
        Debug.Log(gameObject.name + " - LateUpdate");


    }

    void OnDisable()
    {
        // Se llama cuando el objeto se deshabilita.
        Debug.Log(gameObject.name + " - OnDisable");
    }

    void OnDestroy()
    {
        // Se llama cuando el objeto se destruye.
        Debug.Log(gameObject.name + " - OnDestroy");
    }
    #endregion

    #region Physics
    void FixedUpdate()
    {
        // Se llama en intervalos de tiempo fijos, ideal para la física.
        Debug.Log(gameObject.name + " - FixedUpdate");

        _rb2D.linearVelocity = Vector2.down * speed;

        if (Physics2D.Raycast(transform.position, Vector2.down))
        {
            _rb2D.linearVelocity += Vector2.right * 2f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Se llama cuando este collider/rigidbody ha comenzado a tocar otro rigidbody/collider.
        Debug.Log(gameObject.name + " - OnCollisionEnter con " + collision.gameObject.name);
    }

    void OnCollisionStay(Collision collision)
    {
        // Se llama una vez por frame para cada collider/rigidbody que está tocando otro rigidbody/collider.
        Debug.Log(gameObject.name + " - OnCollisionStay con " + collision.gameObject.name);
    }

    void OnCollisionExit(Collision collision)
    {
        // Se llama cuando este collider/rigidbody ha dejado de tocar otro rigidbody/collider.
        Debug.Log(gameObject.name + " - OnCollisionExit con " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        // Se llama cuando el collider 'other' entra en el trigger.
        Debug.Log(gameObject.name + " - OnTriggerEnter con " + other.gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        // Se llama una vez por frame mientras el collider 'other' está dentro del trigger.
        Debug.Log(gameObject.name + " - OnTriggerStay con " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        // Se llama cuando el collider 'other' ha dejado de estar dentro del trigger.
        Debug.Log(gameObject.name + " - OnTriggerExit con " + other.gameObject.name);
    }
    #endregion

    #region Physics 2D
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se llama cuando este collider2D/rigidbody2D ha comenzado a tocar otro rigidbody2D/collider2D.
        Debug.Log(gameObject.name + " - OnCollisionEnter2D con " + collision.gameObject.name);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // Se llama una vez por frame para cada collider2D/rigidbody2D que está tocando otro rigidbody2D/collider2D.
        Debug.Log(gameObject.name + " - OnCollisionStay2D con " + collision.gameObject.name);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Se llama cuando este collider2D/rigidbody2D ha dejado de tocar otro rigidbody2D/collider2D.
        Debug.Log(gameObject.name + " - OnCollisionExit2D con " + collision.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Se llama cuando el collider2D 'other' entra en el trigger2D.
        Debug.Log(gameObject.name + " - OnTriggerEnter2D con " + other.gameObject.name);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Se llama una vez por frame mientras el collider2D 'other' está dentro del trigger2D.
        Debug.Log(gameObject.name + " - OnTriggerStay2D con " + other.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Se llama cuando el collider2D 'other' ha dejado de estar dentro del trigger2D.
        Debug.Log(gameObject.name + " - OnTriggerExit2D con " + other.gameObject.name);
    }
    #endregion

    #region Animation
    void OnAnimatorIK(int layerIndex)
    {
        // Se llama en cada frame de actualización de IK de la animación.
        Debug.Log(gameObject.name + " - OnAnimatorIK en capa " + layerIndex);
    }

    void OnAnimatorMove()
    {
        // Se llama en cada frame de actualización de movimiento de la animación.
        Debug.Log(gameObject.name + " - OnAnimatorMove");
    }
    #endregion

    #region Input
    void OnMouseDown()
    {
        // Se llama cuando el usuario presiona el botón del mouse mientras está sobre el collider.
        Debug.Log(gameObject.name + " - OnMouseDown");
    }

    void OnMouseDrag()
    {
        // Se llama cada frame mientras el usuario arrastra el mouse sobre el collider.
        Debug.Log(gameObject.name + " - OnMouseDrag");
    }

    void OnMouseEnter()
    {
        // Se llama cuando el mouse entra en el collider.
        Debug.Log(gameObject.name + " - OnMouseEnter");
    }

    void OnMouseExit()
    {
        // Se llama cuando el mouse sale del collider.
        Debug.Log(gameObject.name + " - OnMouseExit");
    }

    void OnMouseOver()
    {
        // Se llama cada frame mientras el mouse está sobre el collider.
        Debug.Log(gameObject.name + " - OnMouseOver");
    }

    void OnMouseUp()
    {
        // Se llama cuando el usuario suelta el botón del mouse mientras está sobre el collider.
        Debug.Log(gameObject.name + " - OnMouseUp");
    }

    void OnMouseUpAsButton()
    {
        // Se llama cuando el usuario suelta el botón del mouse mientras está sobre el collider y no se ha movido.
        Debug.Log(gameObject.name + " - OnMouseUpAsButton");
    }
    #endregion

    #region Rendering
    void OnPreCull()
    {
        // Se llama antes de que la cámara culle la escena.
        Debug.Log(gameObject.name + " - OnPreCull");
    }

    void OnBecameVisible()
    {
        // Se llama cuando el objeto se vuelve visible para cualquier cámara.
        Debug.Log(gameObject.name + " - OnBecameVisible");
    }

    void OnBecameInvisible()
    {
        // Se llama cuando el objeto deja de ser visible para cualquier cámara.
        Debug.Log(gameObject.name + " - OnBecameInvisible");
    }

    void OnPreRender()
    {
        // Se llama antes de que la cámara renderice la escena.
        Debug.Log(gameObject.name + " - OnPreRender");
    }

    void OnRenderObject()
    {
        // Se llama después de que la cámara ha terminado de renderizar la escena.
        Debug.Log(gameObject.name + " - OnRenderObject");
    }

    void OnPostRender()
    {
        // Se llama después de que la cámara ha terminado de renderizar la escena.
        Debug.Log(gameObject.name + " - OnPostRender");
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        // Se llama después de que la cámara ha terminado de renderizar la escena, permitiendo modificar la imagen.
        Debug.Log(gameObject.name + " - OnRenderImage");
        Graphics.Blit(src, dest);
    }

    void OnDrawGizmos()
    {
        // Se llama para dibujar gizmos que se pueden ver en la vista de escena.
        Debug.Log(gameObject.name + " - OnDrawGizmos");

        Debug.DrawLine(transform.position, transform.position + Vector3.down * detectionRayLength);
    }

    void OnDrawGizmosSelected()
    {
        // Se llama para dibujar gizmos solo si el objeto está seleccionado.
        Debug.Log(gameObject.name + " - OnDrawGizmosSelected");
    }
    #endregion

    #region Application
    void OnApplicationPause(bool pauseStatus)
    {
        // Se llama cuando la aplicación se pausa o se reanuda.
        Debug.Log(gameObject.name + " - OnApplicationPause: " + pauseStatus);
    }

    void OnApplicationQuit()
    {
        // Se llama cuando la aplicación está a punto de cerrarse.
        Debug.Log(gameObject.name + " - OnApplicationQuit");
    }
    #endregion
}
