using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10;
    private int _upperBound = 9;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePath();
    }

    void CalculatePath()
    {
        transform.Translate(new Vector2(0, _speed * Time.deltaTime));
        if (transform.position.y >= _upperBound)
        {
            Destroy(this.gameObject);
        }
    }
}
