using UnityEngine;

// Clase estática que gestiona las puntuaciones globales.
public static class L_Static
{
    // Miembro estático para almacenar la puntuación más alta.
    public static int highScore;

    // Constructor estático para inicializar la puntuación más alta.
    static L_Static()
    {
        highScore = 0;
        Debug.Log("GlobalScoreManager - Constructor estático: Puntuación más alta inicializada a " + highScore);
    }

    // Método estático para actualizar la puntuación más alta.
    public static void UpdateHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScore = newScore;
            Debug.Log("GlobalScoreManager - Nueva puntuación más alta: " + highScore);
        }
    }
}

// Clase que representa el sistema de puntuaciones de un jugador.
public class PlayerScore : MonoBehaviour
{
    // Puntuación actual del jugador.
    public int currentScore;

    void Start()
    {
        // Inicializa la puntuación del jugador.
        currentScore = 0;
        Debug.Log(gameObject.name + " - Start: Puntuación inicializada a " + currentScore);
    }

    void Update()
    {
        // Incrementa la puntuación del jugador por cada frame (solo para demostración).
        currentScore += 1;

        // Actualiza la puntuación más alta global si la puntuación actual es mayor.
        L_Static.UpdateHighScore(currentScore);

        // Muestra la puntuación actual y la puntuación más alta global.
        Debug.Log(gameObject.name + " - Update: Puntuación actual = " + currentScore + ", Puntuación más alta = " + L_Static.highScore);
    }
}
