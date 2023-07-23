using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zombe : MonoBehaviour
{
    public enum State
    {
        Regular,
        Death
    }

    [SerializeField] private float _speed = 5;
    [SerializeField] private float _maxHealth = 1;
    [SerializeField] public float DeathTime = 1;
    [SerializeField][ReadOnly] public State CurrentState;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Transform _player;
    private float _health;
    private float TimeInDeathState;

    public UnityEvent OnHit;
    public UnityEvent OnDeath;
    public UnityEvent OnRemove;

    private void Awake()
    {
        _health = _maxHealth;
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        switch (CurrentState)
        {
            case State.Regular:
                _RegularStateUpdate();
                break;
            case State.Death:
                _DeathStateUpdate();
                break;
        }
    }

    private void _DeathStateUpdate()
    {
        TimeInDeathState += Time.deltaTime;
        if (TimeInDeathState >= DeathTime)
        {
            OnRemove.Invoke();
            Destroy(gameObject);
        }
    }

    private void _RegularStateUpdate()
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
        if (CurrentState == State.Death) return;
        CurrentState = State.Death;
        _collider.enabled = false;
        TimeInDeathState = 0;
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
