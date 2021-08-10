using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDestroyer : MonoBehaviour
{

    void Update()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }
}
