using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : Upgrade
{
    [SerializeField]
    private float _damage;
    public float Damage { get; }
    [SerializeField]
    private float _velocity;
    public float Velocity { get; }
}
