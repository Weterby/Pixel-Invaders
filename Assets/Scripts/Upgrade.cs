using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField]
    protected string _upgradeName;
    public string UpgradeName { get; set; }

    [SerializeField]
    protected int itemID;
    public int ItemID {
        get { return itemID; }
    }

}
