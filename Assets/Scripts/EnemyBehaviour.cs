using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _bottomBound = -6f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePath();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(gameObject);

            //get Player script component so we can change health value
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                player.ReceiveDamage();
            }
        }
        
    }

    void CalculatePath()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        if (transform.position.y <= _bottomBound)
        {
            transform.position = new Vector2(Random.Range(-10f, 10f), 8f);
        }
    }
}
