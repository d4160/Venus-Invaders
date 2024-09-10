using UnityEngine;
using System.Collections.Generic;

public class I_ArraysAndLists : MonoBehaviour
{
    // Arrays
    public string[] itemNames = new string[5]; // Array de nombres de objetos
    public int[] itemQuantities = { 10, 5, 2, 1, 0 }; // Array de cantidades de objetos
    public GameObject[] itemPrefabs; // Array de prefabs de objetos

    // Listas
    public List<string> collectedItems = new List<string>(); // Lista de objetos recolectados
    public List<int> collectedQuantities = new List<int>(); // Lista de cantidades recolectadas
    public List<GameObject> collectedPrefabs = new List<GameObject>(); // Lista de prefabs recolectados

    void Start()
    {
        // Inicialización de arrays
        itemNames[0] = "Poción";
        itemNames[1] = "Espada";
        itemNames[2] = "Escudo";
        itemNames[3] = "Armadura";
        itemNames[4] = "Anillo";

        // Inicialización de listas
        collectedItems.Add("Poción");
        collectedQuantities.Add(1);
        collectedPrefabs.Add(itemPrefabs[0]);

        // Mostrar contenido de arrays
        Debug.Log($"{gameObject.name} - Arrays:");
        for (int i = 0; i < itemNames.Length; i++)
        {
            Debug.Log($"Item: {itemNames[i]}, Cantidad: {itemQuantities[i]}");
        }

        // Mostrar contenido de listas
        Debug.Log($"{gameObject.name} - Listas:");
        for (int i = 0; i < collectedItems.Count; i++)
        {
            Debug.Log($"Item: {collectedItems[i]}, Cantidad: {collectedQuantities[i]}");
        }

        // Operaciones con listas
        collectedItems.Remove("Poción");
        collectedQuantities.RemoveAt(0);
        collectedPrefabs.Clear();

        Debug.Log($"{gameObject.name} - Listas después de operaciones:");
        for (int i = 0; i < collectedItems.Count; i++)
        {
            Debug.Log($"Item: {collectedItems[i]}, Cantidad: {collectedQuantities[i]}");
        }
    }
}
