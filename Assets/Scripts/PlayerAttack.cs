using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AProjectile _projectilePrefab;
    [SerializeField] private Vector2 _projectileLaunchPositionOffset = Vector2.zero;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        AProjectile projectile = Instantiate(_projectilePrefab);
        projectile.Set(Vector2.right);
        projectile.transform.position = transform.position + (Vector3)_projectileLaunchPositionOffset;
    }
}
