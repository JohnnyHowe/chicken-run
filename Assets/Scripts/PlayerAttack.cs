using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private AProjectile _projectilePrefab;
    [SerializeField] private Vector2 _projectileLaunchPositionOffset = Vector2.zero;

    private void Update()
    {
        // TODO controller support
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    private void Attack()
    {
        AProjectile projectile = Instantiate(_projectilePrefab);
        projectile.Set(GetAimDirection());
        projectile.transform.position = transform.position + (Vector3)_projectileLaunchPositionOffset;
    }

    public Vector2 GetAimDirection()
    {
        // TODO controller support
        return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position + (Vector3)_projectileLaunchPositionOffset).normalized;
    }
}
