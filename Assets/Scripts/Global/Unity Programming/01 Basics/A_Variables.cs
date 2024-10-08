using UnityEngine;

namespace Global.UnityProgramming.Basics
{
    // Declaración del enum (Tipo de Valor)
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    /// <summary>
    /// Ejemplo de interfaz (Tipo de Referencia)
    /// </summary>
    public interface IExample
    {
        void ExampleMethod();
    }

    public class A_Variables : MonoBehaviour
    {
        #region Tipos de Valor
        // Tipos de Valor
        // Estos tipos almacenan directamente los datos y se asignan en la pila de memoria.

        // Tipos Numéricos
        /// <summary>
        /// Tipo entero (4 bytes)
        /// </summary>
        [Tooltip("Tipo entero (4 bytes)")]
        public int integer = 10;

        /// <summary>
        /// Tipo flotante (4 bytes)
        /// </summary>
        [Tooltip("Tipo flotante (4 bytes)")]
        public float floatingPoint = 10.5f;

        /// <summary>
        /// Tipo doble (8 bytes)
        /// </summary>
        [Tooltip("Tipo doble (8 bytes)")]
        public double doublePrecision = 20.5;

        /// <summary>
        /// Tipo corto (2 bytes)
        /// </summary>
        [Tooltip("Tipo corto (2 bytes)")]
        public short shortInteger = 30000;

        /// <summary>
        /// Tipo corto sin signo (2 bytes)
        /// </summary>
        [Tooltip("Tipo corto sin signo (2 bytes)")]
        public ushort ushortInteger = 60000;

        /// <summary>
        /// Tipo largo (8 bytes)
        /// </summary>
        [Tooltip("Tipo largo (8 bytes)")]
        public long longInteger = 10000000000L;

        /// <summary>
        /// Tipo largo sin signo (8 bytes)
        /// </summary>
        [Tooltip("Tipo largo sin signo (8 bytes)")]
        public ulong ulongInteger = 20000000000UL;

        /// <summary>
        /// Tipo byte (1 byte)
        /// </summary>
        [Tooltip("Tipo byte (1 byte)")]
        public byte byteValue = 255;

        /// <summary>
        /// Tipo byte con signo (1 byte)
        /// </summary>
        [Tooltip("Tipo byte con signo (1 byte)")]
        public sbyte sbyteValue = -128;

        /// <summary>
        /// Tipo carácter (2 bytes)
        /// </summary>
        [Tooltip("Tipo carácter (2 bytes)")]
        public char character = 'A';

        // Tipos Booleanos
        /// <summary>
        /// Tipo booleano (1 byte)
        /// </summary>
        [Tooltip("Tipo booleano (1 byte)")]
        public bool boolean = true;

        /// <summary>
        /// Tipo enumeración (enum) - tamaño depende del tipo subyacente, por defecto es int (4 bytes)
        /// </summary>
        [Tooltip("Tipo enumeración (enum) - tamaño depende del tipo subyacente, por defecto es int (4 bytes)")]
        public Direction direction = Direction.North;

        /// <summary>
        /// Tipo estructura (struct) - tamaño depende de los campos
        /// </summary>
        [Tooltip("Tipo estructura (struct) - tamaño depende de los campos")]
        public Point point = new Point { x = 5, y = 10 };
        #endregion

        #region Tipos de Referencia
        // Tipos de Referencia
        // Estos tipos almacenan una referencia a los datos, que se asignan en el montón de memoria.

        // Tipos de Texto
        /// <summary>
        /// Tipo cadena de texto (tamaño variable, 2 bytes por carácter)
        /// </summary>
        [Tooltip("Tipo cadena de texto (tamaño variable, 2 bytes por carácter)")]
        public string text = "Hola, Unity!";

        /// <summary>
        /// Tipo objeto (tamaño variable)
        /// </summary>
        [Tooltip("Tipo objeto (tamaño variable)")]
        public object obj = new object();

        /// <summary>
        /// Tipo clase (tamaño variable)
        /// </summary>
        [Tooltip("Tipo clase (tamaño variable)")]
        public Person person = new Person { name = "Juan", age = 30 };

        /// <summary>
        /// Tipo arreglo (tamaño variable, depende del tipo y número de elementos)
        /// </summary>
        [Tooltip("Tipo arreglo (tamaño variable, depende del tipo y número de elementos)")]
        public int[] array = { 1, 2, 3, 4, 5 };

        // Declaración del delegado
        public delegate void MyDelegate(string message);
        /// <summary>
        /// Tipo delegado (tamaño variable)
        /// </summary>
        [Tooltip("Tipo delegado (tamaño variable)")]
        public MyDelegate myDelegate = Message;

        #endregion

        void Start()
        {
            // Ejemplo de uso del delegado
            myDelegate("Hola desde el delegado!");

            // Llamada al método que muestra la diferencia entre tipos de valor y referencia
            MostrarDiferenciaTipos();

            // Ejemplo de uso de la interfaz
            IExample example = new ExampleClass();
            example.ExampleMethod();
        }

        static void Message(string message)
        {
            Debug.Log(message);
        }

        /// <summary>
        /// Muestra la diferencia entre tipos de valor y tipos de referencia.
        /// </summary>
        void MostrarDiferenciaTipos()
        {
            // Tipo de valor
            int valorA = 10;
            int valorB = valorA;
            valorB = 20;
            Debug.Log($"Tipo de Valor - valorA: {valorA}, valorB: {valorB}"); // valorA: 10, valorB: 20

            // Tipo de referencia
            Person personaA = new Person { name = "Juan", age = 30 };
            Person personaB = personaA;
            personaB.age = 40;
            Debug.Log($"Tipo de Referencia - personaA.age: {personaA.age}, personaB.age: {personaB.age}"); // personaA.age: 40, personaB.age: 40
        }

        // Declaración del struct (Tipo de Valor)
        [System.Serializable]
        public struct Point
        {
            public int x; // 4 bytes
            public int y; // 4 bytes
        }

        // Declaración del class (Tipo de Referencia)
        [System.Serializable]
        public class Person
        {
            public string name; // tamaño variable, 2 bytes por carácter
            public int age; // 4 bytes
        }

        public class ExampleClass : IExample
        {
            public void ExampleMethod()
            {
                Debug.Log("Método de la interfaz implementado.");
            }
        }
    }
}