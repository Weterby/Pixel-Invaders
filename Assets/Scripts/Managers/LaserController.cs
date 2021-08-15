using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private List<int> _keys;
    [SerializeField]
    private List<GameObject> _values;
    [SerializeField]
    Dictionary<int, GameObject> _weaponPrefabs;

    [SerializeField]
    private Player player;

    private void Start()
    {
        _keys = new List<int>();
        for(int i=0; i < _values.Count;i++)
        {
            _keys.Add(i);
        }
        //map both lists (keys and values) and merge it to dictionary
        _weaponPrefabs = _keys.Zip(_values, (k, v) => new { Key = k, Value = v })
                     .ToDictionary(x => x.Key, x => x.Value);
    }

    public GameObject FindWeapon(int itemID)
    {
        if (_weaponPrefabs.ContainsKey(itemID))
        {
            return _weaponPrefabs[itemID];
        }
        else return null;
    }
}
