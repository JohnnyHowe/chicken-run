using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Zombe))]
public class ZombieView : MonoBehaviour
{
    [SerializeField] private TransformFlipBookFlipper _flipper;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _hitColor = Color.red;
    [SerializeField] private float _hitColorFadeTime = 1f;

    private Zombe _zomb;
    private float _timeSinceHit;
    private Color _defaultColor;

    private void Start()
    {
        _zomb = GetComponent<Zombe>();
        _zomb.OnHit.AddListener(OnHit);

        _defaultColor = _spriteRenderer.color;
        _timeSinceHit = _hitColorFadeTime;
    }

    private void Update()
    {
        _flipper.SetTargetDirection(_zomb.GetTargetDirection().x);

        if (_timeSinceHit < _hitColorFadeTime) {
            _timeSinceHit = Mathf.Min(_timeSinceHit + Time.deltaTime, _hitColorFadeTime);
            _spriteRenderer.color = Color.Lerp(_hitColor, _defaultColor, _timeSinceHit / _hitColorFadeTime);
        }
    }

    public void OnHit()
    {
        _timeSinceHit = 0;
    }
}
