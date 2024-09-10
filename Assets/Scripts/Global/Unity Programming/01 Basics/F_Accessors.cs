using UnityEngine;

public class F_Accessors : MonoBehaviour
{
    // Variable pública para la salud máxima del personaje.
    public int maxHealth = 100;

    // Variable privada para la salud actual del personaje.
    private int _currentHealth;

    // Variable protegida que puede ser accedida por clases derivadas.
    protected bool _isAlive = true;

    // Variable interna que puede ser accedida dentro del mismo ensamblado.
    internal string characterName = "Player";

    // Método Awake se llama cuando el script de la instancia se está cargando.
    void Awake()
    {
        // Inicializa la salud actual al valor máximo de salud.
        _currentHealth = maxHealth;
        Debug.Log(gameObject.name + " - Awake: Salud inicializada a " + _currentHealth);
    }

    // Método público para recibir daño.
    public void TakeDamage(int damage)
    {
        // Reduce la salud actual por la cantidad de daño recibido.
        _currentHealth -= damage;
        Debug.Log(gameObject.name + " - TakeDamage: Salud reducida a " + _currentHealth);

        // Verifica si la salud ha caído por debajo de cero.
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    // Método privado para manejar la muerte del personaje.
    private void Die()
    {
        // Lógica para la muerte del personaje.
        _isAlive = false;
        Debug.Log(gameObject.name + " - Die: El personaje ha muerto.");
        // Aquí podrías añadir lógica para desactivar el personaje, reproducir una animación, etc.
    }

    // Método público para curarse.
    public void Heal(int amount)
    {
        // Incrementa la salud actual por la cantidad de curación recibida.
        _currentHealth += amount;

        // Asegura que la salud actual no exceda la salud máxima.
        if (_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }

        Debug.Log(gameObject.name + " - Heal: Salud aumentada a " + _currentHealth);
    }

    // Método Update se llama una vez por frame.
    void Update()
    {
        // Ejemplo de uso de las funciones TakeDamage y Heal para pruebas.
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10); // Cura 10 puntos de salud al presionar la tecla H.
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            TakeDamage(20); // Recibe 20 puntos de daño al presionar la tecla D.
        }
    }
}

// Clase que representa un objeto que puede curar al personaje.
public class Healer : MonoBehaviour
{
    // Referencia al sistema de salud del personaje.
    public F_Accessors healthSystem;

    // Método para curar al personaje.
    public void HealCharacter(int amount)
    {
        if (healthSystem != null)
        {
            healthSystem.Heal(amount);
            Debug.Log(gameObject.name + " - HealCharacter: Curando al personaje por " + amount + " puntos.");
        }
    }
}
