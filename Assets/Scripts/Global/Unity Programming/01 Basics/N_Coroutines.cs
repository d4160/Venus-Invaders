using UnityEngine;
using System.Collections;

public class N_Coroutines : MonoBehaviour
{
    // Variable para controlar el movimiento del objeto.
    public float moveSpeed = 5.0f;

    void Start()
    {
        // Inicia varias coroutines.
        StartCoroutine(WaitAndPrint(2.0f));
        StartCoroutine(MoveObject(Vector3.right, 3.0f));
        StartCoroutine(RepeatAction(1.0f));
    }

    // Coroutine que espera un tiempo y luego imprime un mensaje.
    private IEnumerator WaitAndPrint(float waitTime)
    {
        Debug.Log("WaitAndPrint - Inicio: " + Time.time);
        yield return new WaitForSeconds(waitTime);
        Debug.Log("WaitAndPrint - Fin: " + Time.time);
    }

    // Coroutine que mueve un objeto en una dirección durante un tiempo.
    private IEnumerator MoveObject(Vector3 direction, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null; // Espera hasta el siguiente frame.
        }
        Debug.Log("MoveObject - Movimiento completado.");
    }

    // Coroutine que repite una acción cada cierto tiempo.
    private IEnumerator RepeatAction(float interval)
    {
        while (true)
        {
            Debug.Log("RepeatAction - Acción repetida: " + Time.time);
            yield return new WaitForSeconds(interval);
        }
    }

    // Coroutine que espera hasta el final del frame.
    private IEnumerator WaitForEndOfFrameExample()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("WaitForEndOfFrameExample - Fin del frame: " + Time.time);
    }

    // Coroutine que espera hasta que una condición se cumpla.
    private IEnumerator WaitUntilExample()
    {
        yield return new WaitUntil(() => Time.time > 5.0f);
        Debug.Log("WaitUntilExample - Condición cumplida: " + Time.time);
    }

    // Coroutine que espera mientras una condición se cumpla.
    private IEnumerator WaitWhileExample()
    {
        yield return new WaitWhile(() => Time.time < 5.0f);
        Debug.Log("WaitWhileExample - Condición terminada: " + Time.time);
    }
}
