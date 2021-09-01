using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _healthPoints = 3;
    [SerializeField]
    private float _shieldPoints = 0;
    public float ShieldPoints
    {
        get { return _shieldPoints; }
        private set { _shieldPoints = value; }
    }
    [SerializeField]
    private float _maxShield = 2;
    public float MaxShield
    {
        get { return _maxShield; }
        private set { _maxShield = value; }
    }
    [SerializeField]
    private GameObject shield;
    public float HealthPoints 
    {
        get { return _healthPoints; }
        private set { _healthPoints = value; }
    }
    [SerializeField]
    private float _maxHealth = 3;
    public float MaxHealth
    {
        get { return _maxHealth; }
        private set { _maxHealth = value; }
    }
[SerializeField]
    private int _speed = 5;
    [SerializeField]
    private float _fireRate = 5f;
    private float _nextFire = 0.0f;

    private Vector2 direction;
    private Weapon weapon;
    private SpawnManager _spawnManager;
    private UI_Manager ui;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        shield.SetActive(false);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("SPAWN MANAGER IS MISSING");
        }

        ui = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (ui == null)
        {
            Debug.LogError("COULDN'T FIND UI MANAGER COMPONENT");
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
    }

    void SpawnLaser()
    {
        _nextFire = Time.time + _fireRate;
        weapon.Shoot();
    }

    public void ReceiveDamage() 
    {
        if (ShieldPoints <= 0)
        {
            _healthPoints -= 1;
            ui.CalculateHealth();
            if (_healthPoints <= 0)
            {
                _spawnManager.OnPlayerDeath();
                ui.OnPlayerDeath();
                Destroy(gameObject);
            }
        }
        else
        {
            ShieldPoints -= 1;
            if(ShieldPoints<=0) shield.SetActive(false);
            ui.CalculateShield();
        }
    }

    public void RegenerateShield()
    {
        shield.SetActive(true);
        ShieldPoints = MaxShield;
        ui.CalculateShield();
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
                case "SUpgrade":
                    RegenerateShield();
                    break;
            }
            Destroy(collision.gameObject);
        }
    }
}
