using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : MonoBehaviour
{
    public abstract void Set(Vector2 direction);
    public abstract float GetContactDamage();
    public abstract void OnHit();
}
