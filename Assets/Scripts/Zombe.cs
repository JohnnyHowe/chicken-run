using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombe : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody2D _rigidBody;
    private Transform _player;

    private void Awake()
    {
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
    }

    private Transform _GetTargetPlayer()
    {
        return _player;
    }
}
