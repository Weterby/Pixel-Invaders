using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultWeapon;

    [SerializeField]
    private int weaponRank;
    private const int WEAPON_MAX_RANK = 3;
    private GameObject laserPrefab;
    public GameObject LaserPrefab { get; set; }
    
    [SerializeField]
    public GameObject[] firePoints; //0 - front 1 - left 2 - right

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
        weaponRank = 1;
    }

    public void ChangeWeapon(int id)
    {
        GameObject temp = laserController.FindWeapon(id);
        if (temp != null) LaserPrefab = temp;
        else Debug.LogError("COULDNT FIND WEAPON WITH GIVEN ID: " + id);
    }

    public void UpgradeWeapon()
    {
        weaponRank++;
        if (weaponRank >= WEAPON_MAX_RANK)
        {
            weaponRank = WEAPON_MAX_RANK;
        }
    }

    public void Shoot()
    {
        switch (weaponRank)
        {
            default:
                Debug.LogWarning("Couldn't find proper fire mode, selecting first rank...");
                Instantiate(LaserPrefab, firePoints[0].transform.position, Quaternion.identity);
                break;

            case 1:
                Instantiate(LaserPrefab, firePoints[0].transform.position, Quaternion.identity);
                break;

            case 2:
                Instantiate(LaserPrefab, firePoints[1].transform.position, Quaternion.identity);
                Instantiate(LaserPrefab, firePoints[2].transform.position, Quaternion.identity);
                break;

            case 3:
                Instantiate(LaserPrefab, firePoints[0].transform.position, Quaternion.identity);
                Instantiate(LaserPrefab, firePoints[1].transform.position, Quaternion.identity);
                Instantiate(LaserPrefab, firePoints[2].transform.position, Quaternion.identity);
                break;
        }
    }
}
