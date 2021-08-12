using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultWeapon;

    private GameObject laserPrefab;
    public GameObject LaserPrefab { get; set; }
    
    [SerializeField]
    //0 - front 1 - left 2 - right
    public GameObject[] firePoints;

    [SerializeField]
    private LaserController laserController;
    [SerializeField]
    private float _laserDamage;
    public float LaserDamage { get; set; }
    [SerializeField]
    private float laserVelocity;
    public float LaserVelocity 
    {
        get { return laserVelocity;  }
        set { laserVelocity = value; }
    }

    private void Start()
    {
        LaserPrefab = defaultWeapon;
    }

    public void ChangeWeapon(int id)
    {
        GameObject temp = laserController.FindWeapon(id);
        Debug.Log(temp);
        if (temp != null) LaserPrefab = temp;
        else Debug.LogError("COULDNT FIND WEAPON WITH GIVEN ID: " + id);
    }

    public void Shoot()
    {
        Instantiate(LaserPrefab, transform.position, Quaternion.identity);
    }
}
