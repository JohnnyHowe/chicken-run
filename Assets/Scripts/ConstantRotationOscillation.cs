using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotationOscillation : MonoBehaviour
{
    [SerializeField] private float _maxAngle = 90f;
    [SerializeField] private float _period = 1f;

    private void Update()
    {
        if (_period == 0) return;
        float t = Mathf.Sin(2 * Mathf.PI * Time.time / _period);
        transform.localRotation = Quaternion.Euler(0, 0, t * _maxAngle);
    }
}
