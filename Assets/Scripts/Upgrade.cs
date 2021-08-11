using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    private string _upgradeName;
    public string UpgradeName { get; }

    [SerializeField]
    private int _itemID;
    public int ItemID { get; }

}
