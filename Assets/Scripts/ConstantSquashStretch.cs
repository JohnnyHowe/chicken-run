using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantSquashStretch : MonoBehaviour
{
    [SerializeField] private Vector3 _squashScale = new Vector3(1.1f, 0.9f, 1);
    [SerializeField] private Vector3 _stretchScale = new Vector3(0.9f, 1.1f, 1);
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
        float t = Mathf.Sin(2 * Mathf.PI * (Time.time + _offset) / _period) * 0.5f + 0.5f;
        transform.localScale = Vector3.Lerp(_squashScale, _stretchScale, t);
    }
}
