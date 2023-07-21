using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationOscillation : MonoBehaviour
{
    [SerializeField] private float _maxAngle = 90f;
    [SerializeField] private float _period = 1f;
    [SerializeField] private bool _randomStart = true;
    private float _offset = 0;

    private void Start()
    {
        if (_randomStart) _offset = _period * Random.Range(0f, 1000f) / 1000f;
    }

    private void Update()
    {
        if (_period == 0) return;
        float t = Mathf.Sin(2 * Mathf.PI * (Time.time + _offset) / _period);
        transform.localRotation = Quaternion.Euler(0, 0, t * _maxAngle);
    }
}
