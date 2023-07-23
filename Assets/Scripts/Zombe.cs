using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombe : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _maxHealth = 1;
    private Rigidbody2D _rigidBody;
    private Transform _player;
    private float _health;

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
        Vector2 targetDirection = (_GetTargetPlayer().position - transform.position).normalized;
        _rigidBody.velocity = targetDirection * _speed;

        if (_health <= 0)
        {
            _Die();
        }
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
        }
    }
}
