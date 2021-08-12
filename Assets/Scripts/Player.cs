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
    private float _fireRate = 1f;
    private float _nextFire = 0.0f;

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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        // transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.fixedDeltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x >= 11 || transform.position.x <= -11)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, 0);
        }
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
            Debug.Log("kolizja");
            int itemID = collision.gameObject.GetComponent<WeaponUpgrade>().ItemID;
            Debug.Log("ID ulepszenia: "+ itemID);
            weapon.ChangeWeapon(itemID);
            Destroy(collision.gameObject);
        }
    }
}
