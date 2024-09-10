using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    private float _damage;

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, float velocity)
    {
        _damage = damage;
        _rb.linearVelocity = transform.right * velocity;
    }
}
