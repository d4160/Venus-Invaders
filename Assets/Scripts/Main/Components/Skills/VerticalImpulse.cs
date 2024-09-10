using DG.Tweening;
using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Habilidad de impulso vertical.
    /// </summary>
    [System.Serializable]
    public class VerticalImpulse : Move
    {
        private ParticleSystem _bottomThruster;
        private ParticleSystem _topThruster;
        private static Material s_defaultParticleMaterial;

        public VerticalImpulse() : base()
        {
            _speed = 5f; // Velocidad en m/s
            _distance = 0.5f; // Distancia en metros
        }

        public override void Start()
        {
            InitializeDefaultParticleMaterial();
        }

        public override void Execute()
        {
            Debug.Log($"Ejecutando impulso vertical con dirección {_direction}");
            Vector2 impulseForce = Vector2.up * _speed * _direction;
            Rb2D.AddForce(impulseForce, ForceMode2D.Impulse);
            PlayMoveAnimation();
            CreateThrusterEffect();
            PlaySound();
        }

        private static void InitializeDefaultParticleMaterial()
        {
            if (s_defaultParticleMaterial == null)
            {
                // Crear un material por defecto para las partículas si no existe
                s_defaultParticleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));
                s_defaultParticleMaterial.color = Color.blue;
            }
        }

        protected override void PlayMoveAnimation()
        {
            // Estirar el sprite verticalmente en la dirección del movimiento
            Vector3 targetScale = new Vector3(1f, 1f + (0.2f * _direction), 1f);
            Rb2D.transform.DOScale(targetScale, 0.2f).OnComplete(() =>
            {
                Rb2D.transform.DOScale(Vector3.one, 0.3f);
            });
        }

        protected override void CreateThrusterEffect()
        {
            if (_bottomThruster == null || _topThruster == null)
            {
                _bottomThruster = CreateThrusterParticleSystem(-0.5f);
                _topThruster = CreateThrusterParticleSystem(0.5f);
            }

            // Activar el propulsor en la dirección opuesta al movimiento
            if (_direction > 0)
            {
                _bottomThruster.Play();
                _topThruster.Stop();
            }
            else
            {
                _topThruster.Play();
                _bottomThruster.Stop();
            }

            DOVirtual.DelayedCall(0.5f, () =>
            {
                _bottomThruster.Stop();
                _topThruster.Stop();
            });
        }

        private void PlaySound()
        {
            if (AudioSource && AudioSource.clip != null)
            {
                AudioSource.Play();
                DOVirtual.DelayedCall(0.5f, () => AudioSource.Stop());
            }
        }

        private ParticleSystem CreateThrusterParticleSystem(float yOffset)
        {
            GameObject thrusterObj = new GameObject("Thruster");
            thrusterObj.transform.SetParent(Rb2D.transform);
            thrusterObj.transform.localPosition = new Vector3(0, yOffset, 0);

            ParticleSystem ps = thrusterObj.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = new ParticleSystem.MinMaxGradient(Color.cyan, Color.blue);
            main.startSize = 0.2f;
            main.startSpeed = 5f;
            main.simulationSpace = ParticleSystemSimulationSpace.World;
            main.startLifetime = 0.5f;

            var emission = ps.emission;
            emission.rateOverTime = 100;

            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Cone;
            shape.angle = 5f;
            shape.radius = 0.1f;

            var colorOverLifetime = ps.colorOverLifetime;
            colorOverLifetime.enabled = true;
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.cyan, 0.0f), new GradientColorKey(Color.blue, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) }
            );
            colorOverLifetime.color = gradient;

            var sizeOverLifetime = ps.sizeOverLifetime;
            sizeOverLifetime.enabled = true;
            sizeOverLifetime.size = new ParticleSystem.MinMaxCurve(1f, 0f);

            var renderer = ps.GetComponent<ParticleSystemRenderer>();
            renderer.material = s_defaultParticleMaterial;
            renderer.renderMode = ParticleSystemRenderMode.Stretch;
            renderer.velocityScale = 0.2f;
            renderer.lengthScale = 2f;

            return ps;
        }
    }
}