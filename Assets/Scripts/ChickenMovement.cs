using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _directionChangePeriod = 1f;
    [SerializeField] private float _directionChangeSpeed = 1f;

    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    private float _timeUntilDirectionChange;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _timeUntilDirectionChange = 0;
    }

    void Update()
    {
        _timeUntilDirectionChange -= Time.deltaTime;
        if (_timeUntilDirectionChange <= 0) {
            _timeUntilDirectionChange += _directionChangePeriod;
            _ChooseNewDirection();
        }

        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, _direction * _speed, Time.deltaTime * _directionChangeSpeed);
    }

    private void _ChooseNewDirection()
    {
        _direction = new Vector2(_Random(), _Random()).normalized;
    }

    /// <summary>
    /// Random float between -1 and 1
    /// </summary>
    private static float _Random()
    {
        return Random.Range(-1000f, 1000f) / 1000f;
    }
}
