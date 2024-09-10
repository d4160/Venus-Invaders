using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Habilidad de movimiento base con Rigidbody2D.
    /// </summary>
    [System.Serializable]
    public class Move : SkillBase
    {
        [SerializeField] protected float _speed = 5f;
        [SerializeField] protected float _distance = 1f;

        protected int _direction = 1;

        public Rigidbody2D Rb2D { get; set; }
        public AudioSource AudioSource { get; set; }

        public virtual void SetDirection(int newDirection)
        {
            _direction = Mathf.Clamp(newDirection, -1, 1);
        }

        public override void Start()
        {

        }

        public override void Update()
        {
            // Lógica de actualización común para movimiento
        }

        public override void Execute()
        {
            Debug.Log("Ejecutando habilidad de movimiento base");
        }

        protected virtual void PlayMoveAnimation()
        {
            // Implementación base para animación de movimiento
        }

        protected virtual void CreateThrusterEffect()
        {
            // Implementación base para efecto de propulsores
        }
    }
}