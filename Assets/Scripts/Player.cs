using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int _health = 3;
    [SerializeField]
    private int _speed = 5;
    [SerializeField]
    private float _fireRate = 5f;
    private float _nextFire = 0.0f;

    private Vector2 direction;
    private Weapon weapon;
    private SpawnManager _spawnManager;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("SPAWN MANAGER IS MISSING");
        }

        weapon = gameObject.GetComponent<Weapon>();
        if(weapon == null)
        {
            Debug.LogError("WEAPON SCRIPT COMPONENT IS MISSING");
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            SpawnLaser();
        }
    }
    private void FixedUpdate()
    {
        CalculateMovement();
    }
    void CalculateMovement()
    {
        transform.Translate(new Vector3(direction.x, direction.y, 0) * _speed * Time.fixedDeltaTime);

        //if (transform.position.y >= 0)
        //{
        //    transform.position = new Vector3(transform.position.x, 0, 0);
        //}
        //else if (transform.position.y <= -3.8f)
        //{
        //    transform.position = new Vector3(transform.position.x, -3.8f, 0);
        //}

        //if (transform.position.x >= 11 || transform.position.x <= -11)
        //{
        //    transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        //}
    }

    void SpawnLaser()
    {
        _nextFire = Time.time + _fireRate;
        weapon.Shoot();
    }

    public void ReceiveDamage() 
    {
        _health -= 1;
        if (_health <= 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //on collision with weapon box - upgrade weapon
        if (collision.gameObject.tag == "Upgrade")
        {
            switch (collision.gameObject.name)
            {
                default:
                    Debug.LogWarning("Can't recognize the upgrade object");
                    break;
                case "WUpgrade":
                    WeaponUpgrade wu = collision.gameObject.GetComponent<WeaponUpgrade>();
                    weapon.ChangeWeapon(wu.ItemID, wu.Damage, wu.Velocity);
                    break;
                case "LUpgrade":
                    weapon.UpgradeWeapon();
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
