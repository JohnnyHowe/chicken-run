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
    [SerializeField] private GameObject _deathParticles;

    private Zombe _zomb;
    private float _timeSinceHit;
    private Color _defaultColor;

    private void Start()
    {
        _zomb = GetComponent<Zombe>();
        _zomb.OnHit.AddListener(OnHit);
        _zomb.OnDeath.AddListener(OnDeath);
        _zomb.OnRemove.AddListener(_SpawnDeathParticles);

        _defaultColor = _spriteRenderer.color;
        _timeSinceHit = _hitColorFadeTime;
    }

    private void Update()
    {
        switch (_zomb.CurrentState)
        {
            case Zombe.State.Regular:
                _RegularStateUpdate();
                break;
            case Zombe.State.Death:
                _DeathStateUpdate();
                break;
        }
    }

    private void _DeathStateUpdate()
    {
        _spriteRenderer.color = _hitColor;
    }

    private void _RegularStateUpdate()
    {
        _flipper.SetTargetDirection(_zomb.GetTargetDirection().x);

        if (_timeSinceHit < _hitColorFadeTime)
        {
            _timeSinceHit = Mathf.Min(_timeSinceHit + Time.deltaTime, _hitColorFadeTime);
            _spriteRenderer.color = Color.Lerp(_hitColor, _defaultColor, _timeSinceHit / _hitColorFadeTime);
        }
    }

    public void OnHit()
    {
        _timeSinceHit = 0;
    }

    public void OnDeath()
    {

    }

    private void _SpawnDeathParticles()
    {
        GameObject deathParticles = Instantiate(_deathParticles);
        deathParticles.transform.position = transform.position;
    }
}
