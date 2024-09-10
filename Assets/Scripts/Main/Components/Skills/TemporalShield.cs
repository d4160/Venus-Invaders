using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Habilidad de escudo temporal.
    /// </summary>
    public class TemporalShieldSkill : SkillBase
    {
        private float duration = 3f;

        public override void Update()
        {
            // Lógica de actualización para el escudo temporal
        }

        public override void Execute()
        {
            Debug.Log("Ejecutando habilidad de escudo temporal");
            // Implementar lógica de escudo temporal
        }

        public override void Start()
        {
            throw new System.NotImplementedException();
        }

    }
}