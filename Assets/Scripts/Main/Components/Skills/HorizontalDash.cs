using DG.Tweening;
using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Habilidad de movimiento horizontal rápido.
    /// </summary>
    [System.Serializable]
    public class HorizontalDash : Move
    {
        private ParticleSystem _leftThruster;
        private ParticleSystem _rightThruster;

        private static Material s_defaultParticleMaterial;

        public HorizontalDash() : base()
        {
            _speed = 4; // Velocidad en m/s
            _distance = 0.31f; // Distancia en metros
        }

        public override void Start()
        {
            InitializeDefaultParticleMaterial();
        }

        public override void Execute()
        {
            Debug.Log($"Ejecutando dash horizontal con dirección {_direction}");
            Vector2 dashForce = Vector2.right * _speed * _direction;
            Rb2D.AddForce(dashForce, ForceMode2D.Impulse);
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
            // Inclinar el sprite horizontalmente en la dirección del movimiento
            float rotationAngle = -15f * _direction;
            Rb2D.transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

            // Volver a la rotación normal después de un breve periodo
            Rb2D.transform.DORotate(Vector3.zero, 0.5f).SetDelay(0.2f);
        }

        protected override void CreateThrusterEffect()
        {
            if (_leftThruster == null || _rightThruster == null)
            {
                _leftThruster = CreateThrusterParticleSystem(-0.5f);
                _rightThruster = CreateThrusterParticleSystem(0.5f);
            }

            // Activar el propulsor en la dirección opuesta al movimiento
            if (_direction > 0)
            {
                _leftThruster.Play();
                _rightThruster.Stop();
            }
            else
            {
                _rightThruster.Play();
                _leftThruster.Stop();
            }

            DOVirtual.DelayedCall(0.5f, () =>
            {
                _leftThruster.Stop();
                _rightThruster.Stop();
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

        private ParticleSystem CreateThrusterParticleSystem(float xOffset)
        {
            GameObject thrusterObj = new GameObject("Thruster");
            thrusterObj.transform.SetParent(Rb2D.transform);
            thrusterObj.transform.localPosition = new Vector3(xOffset, 0, 0);

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