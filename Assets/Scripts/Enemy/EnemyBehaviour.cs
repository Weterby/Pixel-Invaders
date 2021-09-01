using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private int pointsWorth=5;
    [SerializeField]
    private float _speed = 4f;
    private float _bottomBound = -6f;

    private UI_Manager ui_manager;
    [SerializeField]
    private Animator anim;
    private GameController gameController;
    private void Start()
    {
        ui_manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        if (ui_manager == null)
        {
            Debug.LogError("COULDN'T FIND UI MANAGER COMPONENT");
        }

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        if (gameController == null)
        {
            Debug.LogError("COULDN'T FIND GAME CONTROLLER COMPONENT");
        }
    }
    void FixedUpdate()
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
        transform.Translate(Vector2.down * _speed * Time.fixedDeltaTime);
        if (transform.position.y <= _bottomBound)
        {
            transform.position = new Vector2(Random.Range(-10f, 10f), 8f);
        }
    }

    public void ReceiveDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        ui_manager.AddScore(pointsWorth);
        DropItems();
        anim.SetTrigger("EnemyDestroy");
        Destroy(gameObject,.25f);
    }

    private void DropItems()
    {
        GameObject drop = gameController.DropItem();
        if (drop != null)
        {            
            GameObject newDrop = Instantiate(drop, transform.position, Quaternion.identity);
            newDrop.name = drop.name;
        }
    }
}
