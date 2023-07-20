using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceHorizontalDirection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _objectToFaceDirectionOf;
    [SerializeField] private float _visualFlipTime = 1;

    private void Update()
    {
        float targetDirection = Mathf.Sign(_objectToFaceDirectionOf.velocity.x);
        if (targetDirection == 0) return;

        if (_visualFlipTime == 0)
        {
            _SetHorizontalScale(targetDirection);
        }

        float flipSpeed = 2 / _visualFlipTime;
        float current = transform.localScale.x;
        _SetHorizontalScale(current + flipSpeed * Time.deltaTime * targetDirection);
    }

    private void _SetHorizontalScale(float x)
    {
        transform.localScale = new Vector3(Mathf.Clamp(x, -1, 1), 1, 1);
    }
}
