using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _lerpSpeed = 1;
    [SerializeField] private bool _lateUpdate = false;

    private void Update()
    {
        if (!_lateUpdate) _Move();
    }

    private void LateUpdate()
    {
        if (_lateUpdate) _Move();
    }

    private void _Move()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position + _offset, Time.deltaTime * _lerpSpeed);
    }
}
