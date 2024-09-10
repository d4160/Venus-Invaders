using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Interfaz base para todas las habilidades.
    /// </summary>
    public interface ISkill
    {
        bool Enabled { get; set; }
        SkillUser SkillUser { get; set; }

        void Start();
        void Update();
        void Execute();
    }

    /// <summary>
    /// Clase base abstracta para todas las habilidades.
    /// </summary>
    public abstract class SkillBase : ISkill
    {
        public bool Enabled { get; set; } = true;
        public SkillUser SkillUser { get; set; }

        public abstract void Start();
        public abstract void Update();
        public abstract void Execute();
    }
}