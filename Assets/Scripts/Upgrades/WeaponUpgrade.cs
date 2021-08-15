using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : Upgrade
{
    [SerializeField]
    private float damage;
    public float Damage
    { 
        get { return damage; }
    }
    [SerializeField]
    private float velocity;
    public float Velocity
    {
        get { return velocity; }
    }
}
