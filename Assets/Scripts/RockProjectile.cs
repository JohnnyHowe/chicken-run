using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockProjectile : AProjectile
{
    [SerializeField] private float _fallSpeed = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _initialVerticalVelocity;
    [SerializeField] private float _intialHeight;
    [SerializeField] private float _damage = 1;

    private Rigidbody2D _rigidbody;
    private float _height;
    private float _verticalVelocity;
    private Vector2 _direction;
    private bool _hasDoneDamage;

    private void Awake()
    {
        _hasDoneDamage = false;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Set(Vector2 direction)
    {
        _direction = direction.normalized;
        _height = _intialHeight;
        _verticalVelocity = _initialVerticalVelocity;

        _rigidbody.velocity = _direction * _speed;
    }

    private void FixedUpdate()
    {
        if (_direction.magnitude == 0) return;

        _verticalVelocity -= Time.fixedDeltaTime * _fallSpeed;
        _height += Time.fixedDeltaTime * _verticalVelocity;

        // _rigidbody.velocity = _direction * _speed + Vector2.up * _verticalVelocity;
        _rigidbody.velocity += Vector2.up * _verticalVelocity * Time.fixedDeltaTime;

        if (_height < 0) Destroy(gameObject);
    }

    public override float GetContactDamage()
    {
        return _hasDoneDamage? 0: _damage;
    }

    public override void OnHit()
    {
        _hasDoneDamage = true;
        Destroy(gameObject);
    }
}
