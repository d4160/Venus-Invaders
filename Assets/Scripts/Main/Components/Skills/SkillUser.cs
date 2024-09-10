using System.Collections.Generic;
using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Clase que representa a un usuario de habilidades.
    /// </summary>
    public class SkillUser : MonoBehaviour
    {
        private List<ISkill> skills = new List<ISkill>();

        /// <summary>
        /// Agrega una nueva habilidad al usuario.
        /// </summary>
        /// <param name="skill">La habilidad a agregar.</param>
        public void AddSkill(ISkill skill)
        {
            if (!skills.Contains(skill))
            {
                skill.SkillUser = this;
                skills.Add(skill);

                if (skill.Enabled)
                {
                    skill.Start();
                }
            }
        }

        /// <summary>
        /// Remueve una habilidad del usuario.
        /// </summary>
        /// <param name="skill">La habilidad a remover.</param>
        public void RemoveSkill(ISkill skill)
        {
            skill.SkillUser = null;
            skills.Remove(skill);
        }

        /// <summary>
        /// Habilita una habilidad específica.
        /// </summary>
        /// <param name="skillType">El tipo de habilidad a habilitar.</param>
        public void EnableSkill<T>() where T : ISkill
        {
            var skill = skills.Find(s => s is T);
            if (skill != null)
            {
                skill.Enabled = true;
            }
        }

        /// <summary>
        /// Deshabilita una habilidad específica.
        /// </summary>
        /// <param name="skillType">El tipo de habilidad a deshabilitar.</param>
        public void DisableSkill<T>() where T : ISkill
        {
            var skill = skills.Find(s => s is T);
            if (skill != null)
            {
                skill.Enabled = false;
            }
        }

        /// <summary>
        /// Usa una habilidad específica.
        /// </summary>
        /// <param name="skillType">El tipo de habilidad a usar.</param>
        public void UseSkill<T>() where T : ISkill
        {
            var skill = skills.Find(s => s is T);
            if (skill != null && skill.Enabled)
            {
                skill.Execute();
            }
        }

        /// <summary>
        /// Actualiza todas las habilidades habilitadas.
        /// </summary>
        private void Update()
        {
            foreach (var skill in skills)
            {
                if (skill.Enabled)
                {
                    skill.Update();
                }
            }
        }
    }
}