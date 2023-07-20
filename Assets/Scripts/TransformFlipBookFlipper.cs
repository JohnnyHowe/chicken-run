using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFlipBookFlipper : MonoBehaviour
{
    [SerializeField] private float _visualFlipTime = 0.1f;
    private float _targetDirection = 1;

    public void SetTargetDirection(float direction)
    {
        _targetDirection = Mathf.Sign(direction);
    }

    private void Update()
    {
        if (_targetDirection == 0) return;

        if (_visualFlipTime == 0)
        {
            _SetHorizontalScale(_targetDirection);
        }

        float flipSpeed = 2 / _visualFlipTime;
        float current = transform.localScale.x;
        _SetHorizontalScale(current + flipSpeed * Time.deltaTime * _targetDirection);
    }

    private void _SetHorizontalScale(float x)
    {
        transform.localScale = new Vector3(Mathf.Clamp(x, -1, 1), 1, 1);
    }
}
