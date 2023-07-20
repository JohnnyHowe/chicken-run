using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TransformFlipBookFlipper))]
public class PlayerVisualFlipper : MonoBehaviour
{
    [SerializeField] private PlayerAttack _player;
    private TransformFlipBookFlipper _flipper;

    private void Awake()
    {
        _flipper = GetComponent<TransformFlipBookFlipper>();
    }

    private void Update()
    {
        _flipper.SetTargetDirection(_player.GetAimDirection().x); 
    }
}
