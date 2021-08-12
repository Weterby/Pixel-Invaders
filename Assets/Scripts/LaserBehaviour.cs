using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Weapon weapon;
    private int _upperBound = 9;

    private void Start()
    {
        weapon = GameObject.FindGameObjectWithTag("Player").GetComponent<Weapon>();
    }
    void FixedUpdate()
    {
        CalculatePath();
    }

    void CalculatePath()
    {
        Debug.Log(weapon.LaserVelocity);
        transform.Translate(new Vector2(0, weapon.LaserVelocity * Time.fixedDeltaTime));
        if (transform.position.y >= _upperBound)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //deal damage
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
