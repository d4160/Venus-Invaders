using UnityEngine;

#region Unity Attributes Example
// Añade el script al menú de componentes bajo "Custom/ExampleComponent".
[AddComponentMenu("Custom/ExampleComponent")]
// Evita que se añadan múltiples instancias de este componente a un GameObject.
[DisallowMultipleComponent]
// Permite que el script se ejecute en el modo de edición.
[ExecuteInEditMode]
// Hace que el script se ejecute siempre, tanto en modo de edición como en tiempo de ejecución.
[ExecuteAlways]
// Añade un enlace de ayuda en el Inspector.
[HelpURL("https://docs.unity3d.com/ScriptReference/")]
// Asegura que el GameObject tenga un componente específico (en este caso, Rigidbody).
[RequireComponent(typeof(Rigidbody))]
// Hace que el GameObject sea seleccionado cuando se hace clic en un hijo en la vista de escena.
[SelectionBase]
// Establece el orden de ejecución predeterminado del script.
[DefaultExecutionOrder(100)]
public class UnityAttributesExample : MonoBehaviour
{
    // Añade un encabezado en el Inspector.
    [Header("Basic Settings")]
    // Añade una descripción emergente para la variable speed en el Inspector.
    [Tooltip("This is a tooltip for the speed variable.")]
    // Restringe el rango de valores que se pueden asignar a la variable speed en el Inspector.
    [Range(0, 10)]
    public float speed = 5.0f;

    // Añade espacio entre variables en el Inspector.
    [Space]
    // Añade un encabezado en el Inspector.
    [Header("Advanced Settings")]
    // Permite que una variable privada sea visible en el Inspector y restringe su rango de valores.
    [SerializeField, Range(0, 100)]
    private int health = 100;

    // Oculta una variable pública en el Inspector.
    [HideInInspector]
    public string hiddenVariable = "This won't show in the Inspector";

    // Permite la edición de texto en múltiples líneas en el Inspector.
    [TextArea]
    public string description = "This is a multi-line text area.";

    // Añade una opción de menú contextual para el método ResetValues.
    [ContextMenu("Reset Values")]
    void ResetValues()
    {
        speed = 5.0f;
        health = 100;
        Debug.Log(gameObject.name + " - Values reset");
    }

    // Añade una opción de menú contextual para el campo healthWithContextMenu.
    [ContextMenuItem("Reset Health", "ResetHealth")]
    public int healthWithContextMenu = 100;

    void ResetHealth()
    {
        healthWithContextMenu = 100;
        Debug.Log(gameObject.name + " - Health reset");
    }

}
#endregion
