using UnityEngine;

public class G_Operators : MonoBehaviour
{
    // Variables de puntuación
    public int score = 0;
    public int bonus = 10;
    public int multiplier = 2;

    // Variables de cadenas
    public string playerName = "Player1";
    public string gameStatus = "Playing";

    void Start()
    {
        // Operadores numéricos
        score += bonus; // Suma
        Debug.Log($"{gameObject.name} - Suma: Score = {score}");

        score -= 5; // Resta
        Debug.Log($"{gameObject.name} - Resta: Score = {score}");

        score *= multiplier; // Multiplicación
        Debug.Log($"{gameObject.name} - Multiplicación: Score = {score}");

        score /= 2; // División
        Debug.Log($"{gameObject.name} - División: Score = {score}");

        score %= 3; // Módulo
        Debug.Log($"{gameObject.name} - Módulo: Score = {score}");

        // Operadores de incremento y decremento
        score++; // Incremento
        Debug.Log($"{gameObject.name} - Incremento: Score = {score}");

        score--; // Decremento
        Debug.Log($"{gameObject.name} - Decremento: Score = {score}");

        // Operadores de comparación
        bool isHighScore = score > 50; // Mayor que
        Debug.Log($"{gameObject.name} - Mayor que: isHighScore = {isHighScore}");

        bool isLowScore = score < 10; // Menor que
        Debug.Log($"{gameObject.name} - Menor que: isLowScore = {isLowScore}");

        bool isEqualScore = score == 20; // Igual a
        Debug.Log($"{gameObject.name} - Igual a: isEqualScore = {isEqualScore}");

        bool isNotEqualScore = score != 15; // Diferente de
        Debug.Log($"{gameObject.name} - Diferente de: isNotEqualScore = {isNotEqualScore}");

        // Operadores lógicos
        bool isPlaying = gameStatus == "Playing" && score > 0; // AND lógico
        Debug.Log($"{gameObject.name} - AND lógico: isPlaying = {isPlaying}");

        bool isGameOver = gameStatus == "GameOver" || score <= 0; // OR lógico
        Debug.Log($"{gameObject.name} - OR lógico: isGameOver = {isGameOver}");

        bool isNotPlaying = !isPlaying; // NOT lógico
        Debug.Log($"{gameObject.name} - NOT lógico: isNotPlaying = {isNotPlaying}");

        // Concatenación de cadenas
        string welcomeMessage = "Welcome " + playerName + "!"; // Concatenación
        Debug.Log($"{gameObject.name} - Concatenación: {welcomeMessage}");

        // Interpolación de cadenas
        string scoreMessage = $"Player {playerName} has a score of {score}."; // Interpolación
        Debug.Log($"{gameObject.name} - Interpolación: {scoreMessage}");
    }
}
