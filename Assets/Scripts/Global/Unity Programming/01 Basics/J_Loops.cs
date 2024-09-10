using UnityEngine;
using System.Collections.Generic;

public class J_Loops : MonoBehaviour
{
    // Lista de puntuaciones de jugadores
    public List<int> playerScores = new List<int> { 10, 20, 30, 40, 50 };

    void Start()
    {
        // Bucle for
        Debug.Log($"{gameObject.name} - Bucle for:");
        for (int i = 0; i < playerScores.Count; i++)
        {
            Debug.Log($"Puntuación del jugador {i + 1}: {playerScores[i]}");
        }

        // Bucle while
        Debug.Log($"{gameObject.name} - Bucle while:");
        int index = 0;
        while (index < playerScores.Count)
        {
            Debug.Log($"Puntuación del jugador {index + 1}: {playerScores[index]}");
            index++;
        }

        // Bucle do-while
        Debug.Log($"{gameObject.name} - Bucle do-while:");
        index = 0;
        do
        {
            Debug.Log($"Puntuación del jugador {index + 1}: {playerScores[index]}");
            index++;
        } while (index < playerScores.Count);

        // Bucle foreach
        Debug.Log($"{gameObject.name} - Bucle foreach:");
        int playerIndex = 1;
        foreach (int score in playerScores)
        {
            Debug.Log($"Puntuación del jugador {playerIndex}: {score}");
            playerIndex++;
        }

        // Bucle for anidado
        Debug.Log($"{gameObject.name} - Bucle for anidado:");
        for (int i = 0; i < playerScores.Count; i++)
        {
            for (int j = 0; j < playerScores.Count; j++)
            {
                Debug.Log($"Comparando jugador {i + 1} con jugador {j + 1}: {playerScores[i]} vs {playerScores[j]}");
            }
        }

        // Bucle while con condición adicional
        Debug.Log($"{gameObject.name} - Bucle while con condición adicional:");
        index = 0;
        while (index < playerScores.Count && playerScores[index] < 40)
        {
            Debug.Log($"Puntuación del jugador {index + 1}: {playerScores[index]}");
            index++;
        }
    }
}
