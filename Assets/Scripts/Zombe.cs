using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombe : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _maxHealth = 1;
    private Rigidbody2D _rigidBody;
    private Transform _player;
    private float _health;

    public UnityEvent OnHit;

    private void Awake()
    {
        _health = _maxHealth;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        _Move();
        if (_health <= 0)
        {
            _Die();
        }
    }

    private void _Move()
    {
        _rigidBody.velocity += GetTargetDirection() * _speed * Time.deltaTime;
    }

    private void _Die()
    {
        Destroy(gameObject);
    }

    private Transform _GetTargetPlayer()
    {
        return _player;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<AProjectile>(out AProjectile projectile))
        {
            _health -= projectile.GetContactDamage();
            projectile.OnHit();
            OnHit.Invoke();
        }
    }

    public Vector2 GetTargetDirection()
    {
        return (_GetTargetPlayer().position - transform.position).normalized;
    }
}
