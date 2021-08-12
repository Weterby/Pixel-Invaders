using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private int _upperBound = 9;
    
    void Update()
    {
        CalculatePath();
    }

    void CalculatePath()
    {
        transform.Translate(new Vector2(0, weapon.LaserVelocity * Time.deltaTime));
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
