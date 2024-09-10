using DG.Tweening;
using UnityEngine;

namespace SkillSystem
{
    /// <summary>
    /// Implements basic shooting functionality with customizable parameters.
    /// </summary>
    [System.Serializable]
    public class Shoot : SkillBase
    {
        [SerializeField, Min(1), Tooltip("Maximum amount of ammo")]
        private int _maxAmmo = 10;

        [SerializeField, Min(0.1f), Tooltip("Time in seconds to recharge one ammo")]
        private float _ammoRechargeTime = 1f;

        [SerializeField, Min(0.1f), Tooltip("Cooldown between shots in seconds")]
        private float _shootCooldown = 0.7f;

        [SerializeField, Min(1), Tooltip("Minimum damage per shot")]
        private int _minDamage = 10;

        [SerializeField, Min(1), Tooltip("Maximum damage per shot")]
        private int _maxDamage = 15;
        [SerializeField, Min(0.1f), Tooltip("Maximum damage per shot")]
        private float _projectileSpeed = 5;

        private int _currentAmmo;
        private float _lastShootTime;
        private float _lastRechargeTime;

        /// <summary>
        /// If true, the weapon will shoot automatically when possible.
        /// </summary>
        public bool AutoShooting { get; set; } = true;

        [SerializeField, Tooltip("Prefab of the projectile to be instantiated")]
        private Projectile _projectilePrefab;

        [SerializeField, Tooltip("Transform representing the point where projectiles spawn")]
        private Transform _shootPoint;

        [SerializeField, Tooltip("Transform of the visual parts for applying effects")]
        private Transform _visualPartsTransform;

        [SerializeField, Tooltip("Sound effect played when shooting")]
        private AudioClip _shootSound;

        [SerializeField, Min(0.01f), Tooltip("Duration of the shoot vibration effect")]
        private float _vibrationDuration = 0.1f;

        [SerializeField, Min(0.01f), Tooltip("Strength of the shoot vibration effect")]
        private float _vibrationStrength = 0.1f;

        public AudioSource AudioSource { get; set; }

        protected virtual void Awake()
        {
            ValidateSerializedFields();
        }

        public override void Start()
        {
            _currentAmmo = _maxAmmo;

            if (AudioSource == null)
            {
                Debug.LogWarning($"AudioSource not found. Shooting sounds will not play.");
            }
        }

        public override void Update()
        {
            RechargeAmmo();
            if (AutoShooting)
            {
                TryShoot();
            }
        }

        public override void Execute()
        {
            TryShoot();
        }

        /// <summary>
        /// Attempts to shoot if conditions are met (enough ammo and cooldown elapsed).
        /// </summary>
        private void TryShoot()
        {
            if (_currentAmmo > 0 && Time.time - _lastShootTime >= _shootCooldown)
            {
                ShootProjectile();
                _currentAmmo--;
                _lastShootTime = Time.time;
            }
        }

        /// <summary>
        /// Instantiates and initializes a projectile, then plays shoot effects.
        /// </summary>
        private void ShootProjectile()
        {
            if (_projectilePrefab == null || _shootPoint == null)
            {
                Debug.LogError($"Projectile prefab or shoot point is null. Cannot shoot.");
                return;
            }

            if (SkillUser == null)
            {
                Debug.LogError($"SkillUser is null. Cannot shoot.");
                return;
            }

            Projectile projectile = SkillUser.Instantiate(_projectilePrefab, _shootPoint.position, _shootPoint.rotation);

            if (projectile != null)
            {
                float damage = Random.Range(_minDamage, _maxDamage + 1);
                projectile.Init(damage, _projectileSpeed);
            }
            else
            {
                Debug.LogWarning($"Projectile component not found on instantiated projectile from {SkillUser.name}.");
            }

            PlayShootEffects();
        }

        /// <summary>
        /// Recharges ammo over time based on the _ammoRechargeTime.
        /// </summary>
        private void RechargeAmmo()
        {
            if (_currentAmmo < _maxAmmo && Time.time - _lastRechargeTime >= _ammoRechargeTime)
            {
                _currentAmmo++;
                _lastRechargeTime = Time.time;
            }
        }

        /// <summary>
        /// Plays visual and audio effects associated with shooting.
        /// </summary>
        protected virtual void PlayShootEffects()
        {
            if (_visualPartsTransform != null)
            {
                // Vibración horizontal (small)
                _visualPartsTransform.DOShakePosition(_vibrationDuration, new Vector3(_vibrationStrength, 0f, 0f), 10, 90, false, true);
            }

            // Sonido de disparo
            if (AudioSource != null && _shootSound != null)
            {
                AudioSource.PlayOneShot(_shootSound);
            }
        }

        /// <summary>
        /// Validates the serialized fields to ensure they have appropriate values.
        /// </summary>
        private void ValidateSerializedFields()
        {
            if (_maxDamage < _minDamage)
            {
                Debug.LogWarning($"Max damage ({_maxDamage}) is less than min damage ({_minDamage}) on {SkillUser.name}. Setting max damage to min damage.");
                _maxDamage = _minDamage;
            }

            if (_projectilePrefab == null)
            {
                Debug.LogError($"Projectile prefab is not set on {SkillUser.name}. Shooting will not work.");
            }

            if (_shootPoint == null)
            {
                Debug.LogError($"Shoot point is not set on {SkillUser.name}. Shooting will not work.");
            }

            if (_visualPartsTransform == null)
            {
                Debug.LogWarning($"Visual parts transform is not set on {SkillUser.name}. Vibration effects will not work.");
            }
        }
    }
}