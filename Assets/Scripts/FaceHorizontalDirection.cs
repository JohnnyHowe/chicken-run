using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformFlipBookFlipper))]
public class FaceHorizontalDirection : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _objectToFaceDirectionOf;
    private TransformFlipBookFlipper _flipper;

    private void Awake() 
    {
        _flipper = GetComponent<TransformFlipBookFlipper>();
    }

    private void Update()
    {
        _flipper.SetTargetDirection(Mathf.Sign(_objectToFaceDirectionOf.velocity.x));
    }
}
