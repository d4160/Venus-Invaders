using UnityEngine;

public class M_DeltaTime : MonoBehaviour
{
    // Velocidad de movimiento del objeto.
    public float moveSpeed = 5.0f;

    // Temporizador para medir el tiempo transcurrido.
    private float timer = 0.0f;

    void Start()
    {
        Debug.Log("TimeExamples - Start: Inicialización completa.");
    }

    void Update()
    {
        // Mueve el objeto en el eje X utilizando Time.deltaTime.
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Incrementa el temporizador utilizando Time.deltaTime.
        timer += Time.deltaTime;

        // Muestra el tiempo transcurrido cada segundo.
        if (timer >= 1.0f)
        {
            Debug.Log("TimeExamples - Update: Tiempo transcurrido = " + timer + " segundos.");
            timer = 0.0f; // Reinicia el temporizador.
        }
    }

    void FixedUpdate()
    {
        // Mueve el objeto en el eje Y utilizando Time.fixedDeltaTime.
        transform.Translate(Vector3.up * moveSpeed * Time.fixedDeltaTime);

        // Muestra el valor de Time.fixedDeltaTime.
        Debug.Log("TimeExamples - FixedUpdate: fixedDeltaTime = " + Time.fixedDeltaTime);
    }
}
